using System;

namespace Sitko.Core.Graylog
{
    public class GraylogLoggingOptions
    {
        public string Host { get; }
        public int Port { get; }

        public GraylogLoggingOptions(string host, int port)
        {
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentException("Host can't be empty", nameof(host));
            }

            Host = host;

            if (port > 0)
            {
                Port = port;
            }
            else
            {
                throw new ArgumentException("Port must be greater than 0", nameof(port));
            }
        }
    }
}