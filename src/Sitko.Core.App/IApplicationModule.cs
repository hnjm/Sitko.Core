using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Sitko.Core.App
{
    public interface IApplicationModule<in TModuleOptions> : IApplicationModule where TModuleOptions : class, new()
    {
        string OptionsKey { get; }

        void ConfigureServices(ApplicationContext context, IServiceCollection services, TModuleOptions startupOptions);

        IEnumerable<Type> GetRequiredModules(ApplicationContext context, TModuleOptions options);
    }

    public interface IApplicationModule
    {
        Task InitAsync(ApplicationContext context, IServiceProvider serviceProvider);

        Task ApplicationStarted(IConfiguration configuration, IHostEnvironment environment,
            IServiceProvider serviceProvider);

        Task ApplicationStopping(IConfiguration configuration, IHostEnvironment environment,
            IServiceProvider serviceProvider);

        Task ApplicationStopped(IConfiguration configuration, IHostEnvironment environment,
            IServiceProvider serviceProvider);
    }

    public interface IHostBuilderModule<in TModuleOptions> : IApplicationModule<TModuleOptions>
        where TModuleOptions : class, new()
    {
        public void ConfigureHostBuilder(ApplicationContext context, IHostBuilder hostBuilder,
            TModuleOptions startupOptions);
    }

    public interface ILoggingModule<in TModuleOptions> : IApplicationModule<TModuleOptions>
        where TModuleOptions : class, new()
    {
        void ConfigureLogging(ApplicationContext context, TModuleOptions options,
            LoggerConfiguration loggerConfiguration);
    }

    public interface IConfigurationModule<in TModuleOptions> : IApplicationModule<TModuleOptions>
        where TModuleOptions : class, new()
    {
        void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder,
            TModuleOptions startupOptions);
    }
}
