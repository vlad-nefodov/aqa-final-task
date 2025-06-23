using Business.Abstractions;

namespace Business.Pages;

public abstract class BasePage<TPage> : PageConfiguration where TPage : BasePage<TPage>
{
    protected readonly IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
    }

    protected abstract string PagePath { get; }

    public string Url => $"{BaseUrl}/{PagePath.TrimStart('/')}";

    public virtual TPage Open()
    {
        Driver.NavigateTo(Url);
        Logger?.Debug($"Navigated to {Url}");

        return (TPage)this;
    }

    public virtual bool IsPageUrlConsistent()
    {
        return Driver.Url == Url;
    }
}