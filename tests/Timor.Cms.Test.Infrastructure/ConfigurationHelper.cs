using System.IO;
using Microsoft.Extensions.Configuration;

namespace Timor.Cms.Test.Infrastructure
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot InitConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            var config = configBuilder.Build();

            return config;
        }
    }
}