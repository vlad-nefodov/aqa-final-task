using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Core.WebDriver.Decorators
{
    public abstract class BaseWebDriverDecorator : IWebDriver
    {
        private readonly IWebDriver _driver;
        private bool _disposed = false;

        protected BaseWebDriverDecorator(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public virtual string Url
        {
            get => _driver.Url;
            set => _driver.Url = value;
        }

        public virtual string Title => _driver.Title;

        public virtual string PageSource => _driver.PageSource;

        public virtual string CurrentWindowHandle => _driver.CurrentWindowHandle;

        public virtual ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public virtual void Close() => _driver.Close();

        public virtual IWebElement FindElement(By by) => _driver.FindElement(by);

        public virtual ReadOnlyCollection<IWebElement> FindElements(By by) => _driver.FindElements(by);

        public virtual IOptions Manage() => _driver.Manage();

        public virtual INavigation Navigate() => _driver.Navigate();

        public virtual void Quit() => _driver.Quit();

        public virtual ITargetLocator SwitchTo() => _driver.SwitchTo();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _driver?.Dispose();
                }

                _disposed = true;
            }
        }

        ~BaseWebDriverDecorator()
        {
            Dispose(false);
        }
    }
}
