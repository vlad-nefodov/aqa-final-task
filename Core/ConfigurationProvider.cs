using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigurationProvider
    {
        public static TestsConfiguration Tests { get; private set; }

        static ConfigurationProvider()
        {
            var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            Tests = cfg.GetSection("TestsConfiguration").Get<TestsConfiguration>()
                ?? throw new InvalidOperationException($"Can't load 'TestsConfiguration' section from configuration file.");
        }
    }
}
