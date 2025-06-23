using Business.Abstractions;

namespace Business.Pages;

public class LoginPage : BasePage<LoginPage>
{
    private readonly Locator _errorMessageLocator;
    private readonly Locator _loginButtonLocator;
    private readonly Locator _passwordInputLocator;
    private readonly Locator _usernameInputLocator;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _usernameInputLocator = LocatorProvider.XPath("//input[@data-test='username']");
        _passwordInputLocator = LocatorProvider.XPath("//input[@data-test='password']");
        _loginButtonLocator = LocatorProvider.XPath("//input[@data-test='login-button']");
        _errorMessageLocator = LocatorProvider.XPath("//h3[@data-test='error']");
    }

    protected override string PagePath => "";

    public LoginPage EnterUsername(string username)
    {
        Driver.EnterText(_usernameInputLocator, username);
        Logger?.Debug("Entered username.");

        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        Driver.EnterText(_passwordInputLocator, password);
        Logger?.Debug("Entered password.");

        return this;
    }

    public LoginPage EnterCredentials(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);

        return this;
    }

    public LoginPage ClearUsername()
    {
        Driver.ClearInput(_usernameInputLocator);
        Logger?.Debug("Cleared username.");

        return this;
    }

    public LoginPage ClearPassword()
    {
        Driver.ClearInput(_passwordInputLocator);
        Logger?.Debug("Cleared password.");

        return this;
    }

    public LoginPage ClickLogin()
    {
        Driver.Click(_loginButtonLocator);
        Logger?.Debug("Clicked login button.");

        return this;
    }

    public bool IsErrorMessageDisplayed()
    {
        return Driver.IsDisplayed(_errorMessageLocator);
    }

    public string GetErrorMessage()
    {
        return Driver.GetText(_errorMessageLocator);
    }

    public InventoryPage LoginSuccessful()
    {
        var inventoryPage = new InventoryPage(Driver);
        Logger?.Debug($"Navigated to {inventoryPage.Url}");

        return inventoryPage;
    }
}