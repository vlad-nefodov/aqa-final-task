using Core.WebDriver.Decorators;
using Core.WebDriver.OptionBuilders;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Core.WebDriver.Factories;

public class WebDriverFactory : IWebDriverFactory
{
    private readonly BrowserType _browserType;

    public WebDriverFactory(BrowserType browserType)
    {
        _browserType = browserType;
    }

    public IWebDriver GetWebDriver()
    {
        IWebDriver driver;

        switch (_browserType)
        {
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptionsBuilder()
                    .WithMaximizedWindow()
                    .WithIncognito()
                    .WithDisabledExtensions()
                    .WithNoInfobars()
                    .WithIgnoreCertificateErrors()
                    .Build();
                driver = new EdgeDriver(edgeOptions);
                driver = new InjectExtendedWebElementDecorator(driver);
                break;
            case BrowserType.Firefox:
                var firefoxOptions = new FirefoxOptionsBuilder()
                    .WithPrivateMode()
                    .WithMaximizedWindow()
                    .WithInsecureCertsAccepted()
                    .Build();
                driver = new FirefoxDriver(firefoxOptions);
                break;
            default:
                throw new NotSupportedException($"Browser type '{_browserType}' is not supported.");
        }

        return driver;
    }
}