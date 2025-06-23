using Microsoft.Extensions.Configuration;

namespace Core;

public static class ConfigurationProvider
{
    static ConfigurationProvider()
    {
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        Tests = cfg.GetSection("TestsConfiguration").Get<TestsConfiguration>()
                ?? throw new InvalidOperationException(
                    "Can't load 'TestsConfiguration' section from configuration file.");
    }

    public static TestsConfiguration Tests { get; private set; }
}