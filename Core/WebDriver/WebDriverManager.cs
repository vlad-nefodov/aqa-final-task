using Core.WebDriver.Factories;
using OpenQA.Selenium;

namespace Core.WebDriver;

public class WebDriverManager
{
    private static readonly Lock _lock = new();
    private static readonly ThreadLocal<IWebDriver> _driver = new();
    private static WebDriverManager? _instance;
    private static IWebDriverFactory? _webDriverFactory;

    private WebDriverManager()
    {
    }

    public static WebDriverManager Instance
    {
        get
        {
            EnsureFactoryInitialized();

            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new WebDriverManager();
                }
            }

            return _instance;
        }
    }

    private static IWebDriver Driver
    {
        get
        {
            if (!_driver.IsValueCreated || _driver.Value == null) _driver.Value = _webDriverFactory.GetWebDriver();

            return _driver.Value;
        }
    }

    public string Url => Driver.Url;

    public static void SetFactory(IWebDriverFactory factory)
    {
        _webDriverFactory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public void Configure(int timeoutSeconds)
    {
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutSeconds);
        Driver.Manage().Window.Maximize();
    }

    public void NavigateTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void Quit()
    {
        if (_driver.IsValueCreated && _driver.Value != null)
        {
            _driver.Value.Quit();
            _driver.Value.Dispose();
            _driver.Value = null;
        }
    }

    public IWebElement FindElement(By by)
    {
        return Driver.FindElement(by);
    }

    private static void EnsureFactoryInitialized()
    {
        if (_webDriverFactory == null)
            throw new InvalidOperationException(
                "WebDriverFactory has not been initialized. Please call SetFactory method to set the WebDriverFactory before accessing the WebDriverManager instance.");
    }
}