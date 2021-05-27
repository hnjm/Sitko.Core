using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sitko.Core.App;

namespace Sitko.Core.Consul.Web
{
    public class ConsulWebClient
    {
        private readonly IConsulClient _consulClient;
        private readonly IOptionsMonitor<ConsulWebModuleOptions> _configMonitor;
        private ConsulWebModuleOptions Options => _configMonitor.CurrentValue;
        private readonly IApplication _application;
        private readonly ILogger<ConsulWebClient> _logger;

        private readonly Uri _uri;
        private readonly string _healthUrl;
        private readonly string _name;

        public ConsulWebClient(IServer server, IConsulClient consulClient,
            IOptionsMonitor<ConsulWebModuleOptions> config,
            IHostEnvironment environment, IApplication application, ILogger<ConsulWebClient> logger)
        {
            _consulClient = consulClient;
            _configMonitor = config;
            _application = application;
            _logger = logger;

            _name = environment.ApplicationName;
            if (Options.ServiceUri != null)
            {
                _uri = Options.ServiceUri;
            }
            else
            {
                var addressesFeature = server.Features.Get<IServerAddressesFeature>();
                var addresses = new List<Uri>();
                foreach (var featureAddress in addressesFeature.Addresses)
                {
                    var preparedAddress = featureAddress
                        .Replace("localhost", Options.IpAddress)
                        .Replace("0.0.0.0", Options.IpAddress)
                        .Replace("[::]", Options.IpAddress);

                    var uriCreated = Uri.TryCreate(preparedAddress, UriKind.Absolute,
                        out var uri);
                    if (uriCreated && uri != null)
                    {
                        addresses.Add(uri);
                    }
                    else
                    {
                        _logger.LogWarning("Can't parse address {Address}", featureAddress);
                    }
                }

                if (!addresses.Any())
                {
                    throw new Exception("No addresses available for consul registration");
                }

                var address = addresses.OrderBy(u => u.Port).FirstOrDefault(u => u.Scheme != "https");
                if (address == null) address = addresses.First();
                _logger.LogInformation("Consul uri: {Uri}", address);
                _uri = address;
            }

            _healthUrl = new Uri(_uri, Options.HealthCheckPath).ToString();
        }

        public async Task RegisterAsync()
        {
            var registration = new AgentServiceRegistration
            {
                ID = _name,
                Name = _name,
                Address = _uri.Host,
                Port = _uri.Port,
                Check = new AgentServiceCheck
                {
                    HTTP = _healthUrl,
                    DeregisterCriticalServiceAfter = Options.DeregisterTimeout,
                    Interval = Options.ChecksInterval
                },
                Tags = new[] {"metrics", $"healthUrl:{_healthUrl}", $"version:{_application.Version}"}
            };

            _logger.LogInformation("Registering in Consul as {Name} on {Host}:{Port}", _name,
                _uri.Host, _uri.Port);
            await _consulClient.Agent.ServiceDeregister(registration.ID);
            var result = await _consulClient.Agent.ServiceRegister(registration);
            _logger.LogInformation("Consul response code: {Code}", result.StatusCode);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            var serviceResponse = await _consulClient.Catalog.Service(_name, "metrics", cancellationToken);
            if (serviceResponse.StatusCode == HttpStatusCode.OK)
            {
                if (serviceResponse.Response.Any())
                {
                    return HealthCheckResult.Healthy();
                }

                if (Options.AutoFixRegistration)
                {
                    //no services. fix registration
                    await RegisterAsync();
                }

                return HealthCheckResult.Degraded($"No service registered with name {_name}");
            }

            return HealthCheckResult.Unhealthy($"Error response from consul: {serviceResponse.StatusCode}");
        }
    }
}
