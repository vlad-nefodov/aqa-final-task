using OpenQA.Selenium.Edge;

namespace Core.WebDriver.OptionBuilders;

public class EdgeOptionsBuilder
{
    private readonly EdgeOptions _options;

    public EdgeOptionsBuilder()
    {
        _options = new EdgeOptions();
    }

    public EdgeOptionsBuilder WithMaximizedWindow()
    {
        _options.AddArgument("--start-maximized");
        return this;
    }

    public EdgeOptionsBuilder WithIncognito()
    {
        _options.AddArgument("--inprivate");
        return this;
    }

    public EdgeOptionsBuilder WithDisabledExtensions()
    {
        _options.AddArgument("--disable-extensions");
        return this;
    }

    public EdgeOptionsBuilder WithNoInfobars()
    {
        _options.AddArgument("--disable-infobars");
        return this;
    }

    public EdgeOptionsBuilder WithIgnoreCertificateErrors()
    {
        _options.AddArgument("--ignore-certificate-errors");
        _options.AcceptInsecureCertificates = true;
        return this;
    }

    public EdgeOptions Build()
    {
        return _options;
    }
}