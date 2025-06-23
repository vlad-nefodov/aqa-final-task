using Business.Abstractions;

namespace Business.Pages
{
    public class LoginPage : BasePage<LoginPage>
    {
        private readonly Locator _usernameInputLocator;
        private readonly Locator _passwordInputLocator;
        private readonly Locator _loginButtonLocator;
        private readonly Locator _errorMessageLocator;

        protected override string PagePath => "";

        public LoginPage(IWebDriver driver) : base(driver) 
        {
            _usernameInputLocator = LocatorProvider.XPath("//input[@data-test='username']");
            _passwordInputLocator = LocatorProvider.XPath("//input[@data-test='password']");
            _loginButtonLocator = LocatorProvider.XPath("//input[@data-test='login-button']");
            _errorMessageLocator = LocatorProvider.XPath("//h3[@data-test='error']");
        }

        public LoginPage EnterUsername(string username)
        {
            _driver.EnterText(_usernameInputLocator, username);
            Logger?.Debug("Entered username.");

            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _driver.EnterText(_passwordInputLocator, password);
            Logger?.Debug("Entered password.");

            return this;
        }

        public LoginPage EnterCridentials(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);

            return this;
        }

        public LoginPage ClearUsername()
        {
            _driver.ClearInput(_usernameInputLocator);
            Logger?.Debug("Cleared username.");

            return this;
        }

        public LoginPage ClearPassword()
        {
            _driver.ClearInput(_passwordInputLocator);
            Logger?.Debug("Cleared password.");

            return this;
        }

        public LoginPage ClickLogin()
        {
            _driver.Click(_loginButtonLocator);
            Logger?.Debug("Clicked login button.");

            return this;
        }

        public bool IsErrorMessageDisplayed() => _driver.IsDisplayed(_errorMessageLocator);

        public string GetErrorMessage() => _driver.GetText(_errorMessageLocator);

        public InventoryPage LoginSuccessful()
        {
            var inventoryPage = new InventoryPage(_driver);
            Logger?.Debug($"Navigated to {inventoryPage.Url}");

            return inventoryPage;
        }
    }
}
