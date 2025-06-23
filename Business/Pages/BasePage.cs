using Business.Abstractions;

namespace Business.Pages
{
    public abstract class BasePage<TPage> : PageConfiguration where TPage : BasePage<TPage>
    {
        protected readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        protected abstract string PagePath { get; }

        public string Url => $"{BaseUrl}/{PagePath.TrimStart('/')}";

        public virtual TPage Open()
        {
            _driver.NavigateTo(Url);
            Logger?.Debug($"Navigated to {Url}");

            return (TPage)this;
        }

        public virtual bool IsPageUrlConsistent() => _driver.Url == Url;
    }
}
