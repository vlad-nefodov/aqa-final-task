using OpenQA.Selenium.Firefox;

namespace Core.WebDriver.OptionBuilders;

public class FirefoxOptionsBuilder
{
    private readonly FirefoxOptions _options;

    public FirefoxOptionsBuilder()
    {
        _options = new FirefoxOptions();
    }

    public FirefoxOptionsBuilder WithPrivateMode()
    {
        _options.AddArgument("-private");
        return this;
    }

    public FirefoxOptionsBuilder WithMaximizedWindow()
    {
        _options.AddArgument("--start-maximized");
        return this;
    }

    public FirefoxOptionsBuilder WithInsecureCertsAccepted()
    {
        _options.AcceptInsecureCertificates = true;
        return this;
    }

    public FirefoxOptions Build()
    {
        return _options;
    }
}