using Business.Abstractions;
using Core.WebDriver;
using OpenQA.Selenium;

namespace Core.Adapters
{
    public class WebDriverPageAdapter : Business.Abstractions.IWebDriver
    {
        private readonly WebDriverManager _webDriver;

        public WebDriverPageAdapter(WebDriverManager webDriver) 
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        public string Url => _webDriver.Url;

        public void ClearInput(Locator locator)
        {
            FindElementByLocator(locator)
                .Clear();
        }

        public void Click(Locator locator)
        {
            FindElementByLocator(locator)
                .Click();
        }

        public void EnterText(Locator locator, string text)
        {
            FindElementByLocator(locator)
                .SendKeys(text);
        }

        public string GetText(Locator locator)
        {
            return FindElementByLocator(locator)
                .Text;
        }

        public bool IsDisplayed(Locator locator)
        {
            return FindElementByLocator(locator)
                .Displayed;
        }

        public void NavigateTo(string url)
        {
            _webDriver.NavigateTo(url);
        }

        private IWebElement FindElementByLocator(Locator locator)
        {
            var by = locator.Type switch
            {
                LocatorType.Id => By.Id(locator.Value),
                LocatorType.Name => By.Name(locator.Value),
                LocatorType.XPath => By.XPath(locator.Value),
                _ => throw new InvalidOperationException()
            };

            return _webDriver.FindElement(by);
        }
    }
}
