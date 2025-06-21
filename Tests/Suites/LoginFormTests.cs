using FluentAssertions;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Tests.Suites
{
    [TestClass]
    public sealed class LoginFormTests
    {
        private readonly By _usernameInputLocator = By.XPath("//input[@data-test='username']");
        private readonly By _passwordInputLocator = By.XPath("//input[@data-test='password']");
        private readonly By _loginButtonLocator = By.XPath("//input[@data-test='login-button']");
        private readonly By _errorMessageLocator = By.XPath("//h3[@data-test='error']");
        private readonly By _dashboardTitle = By.XPath("//div[contains(@class, 'app_logo')]");

        private ILogger _logger;
        private IWebDriver _driver;

        [TestInitialize]
        public void TestInitialize()
        {
            _logger = LogManager.GetCurrentClassLogger();

            _logger.Info("Initializing WebDriver...");
            _driver = new FirefoxDriver();

            _logger.Info("Applying WebDriver configurations...");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _logger.Info("Navigated to SauceDemo");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _logger.Info("Closing WebDriver...");
            _driver.Quit();
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC1_Data), typeof(DataProvider))]
        public void UC1_LoginWithEmptyCredentials_ShowsUsernameRequired(string username, string password)
        {
            _logger.Info("Starting UC1 test...");

            string expectedErrorMessage = "Username is required";

            var usernameInput = _driver.FindElement(_usernameInputLocator);
            var passwordInput = _driver.FindElement(_passwordInputLocator);
            var loginButton = _driver.FindElement(_loginButtonLocator);

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            _logger.Info("Entered credentials");

            usernameInput.Clear();
            passwordInput.Clear();
            _logger.Info("Cleared both fields");

            loginButton.Click();
            _logger.Info("Clicked login");

            var errorMessage = _driver.FindElement(_errorMessageLocator).Text;
            errorMessage.Should().Contain(expectedErrorMessage);

            _logger.Info("UC1 test passed");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC2_Data), typeof(DataProvider))]
        public void UC2_LoginWithEmptyPassword_ShowsPasswordRequired(string username, string password)
        {
            _logger.Info("Starting UC2 test...");

            string expectedErrorMessage = "Password is required";

            var usernameInput = _driver.FindElement(_usernameInputLocator);
            var passwordInput = _driver.FindElement(_passwordInputLocator);
            var loginButton = _driver.FindElement(_loginButtonLocator);

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            _logger.Info("Entered credentials");

            passwordInput.Clear();
            _logger.Info("Cleared password field");

            loginButton.Click();
            _logger.Info("Clicked login");

            var errorMessage = _driver.FindElement(_errorMessageLocator).Text;
            errorMessage.Should().Contain(expectedErrorMessage);

            _logger.Info("UC2 test passed");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC3_Data), typeof(DataProvider))]
        public void UC3_LoginWithValidCredentials_DisplaysDashboardWithValidTitle(string username, string password)
        {
            _logger.Info("Starting UC3 test...");

            string expectedTitle = "Swag Labs";

            var usernameInput = _driver.FindElement(_usernameInputLocator);
            var passwordInput = _driver.FindElement(_passwordInputLocator);
            var loginButton = _driver.FindElement(_loginButtonLocator);

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            _logger.Info("Entered credentials");

            loginButton.Click();
            _logger.Info("Clicked login");

            var dashboardTitle = _driver.FindElement(_dashboardTitle).Text;
            dashboardTitle.Should().Be(expectedTitle);

            _logger.Info("UC3 test passed");
        }
    }
}
