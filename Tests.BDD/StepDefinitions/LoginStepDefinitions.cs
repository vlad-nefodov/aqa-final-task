using Business.Abstractions;
using Business.Pages;
using Core;
using Core.Adapters;
using Core.WebDriver;
using Core.WebDriver.Factories;
using FluentAssertions;
using NLog;
using ILogger = NLog.ILogger;

namespace Tests.BDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private static ILogger _logger;
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions()
        {
            var driver = new WebDriverPageAdapter(WebDriverManager.Instance);
            _loginPage = new LoginPage(driver);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var cfg = ConfigurationProvider.Tests;
            var webDriverFactory = new WebDriverFactory(cfg.BrowserType);

            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info("Initializing WebDriver...");

            WebDriverManager.SetFactory(webDriverFactory);

            PageConfiguration.BaseUrl = cfg.BaseUrl;
            PageConfiguration.LocatorProvider = new LocatorProvider();
            PageConfiguration.Logger = new LoggerAdapter(_logger);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            _logger.Info("Configuting WebDriver...");
            WebDriverManager.Instance.Configure(5);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            WebDriverManager.Instance.Quit();
            _logger.Info("Closed WebDriver");
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.Open();
        }

        [When("I enter (.*) and (.*)")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _loginPage
                .EnterUsername(username)
                .EnterPassword(password);
        }

        [When("I clear the username and password fields")]
        public void WhenIClearTheUsernameAndPasswordFields()
        {
            _loginPage
                .ClearUsername()
                .ClearPassword();
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then("I should see the error message {string}")]
        public void ThenIShouldSeeTheErrorMessage(string expectedErrorMessage)
        {
            _loginPage
                .IsPageUrlConsistent()
                .Should()
                .BeTrue();
            _logger.Info("Verified URL is consistent");

            _loginPage
                .IsErrorMessageDisplayed()
                .Should()
                .BeTrue();
            _logger.Info("Verified error message is displayed");

            _loginPage
                .GetErrorMessage()
                .Should()
                .Contain(expectedErrorMessage);
            _logger.Info("Verified error message contains expected text");
        }

        [When("I clear the password field")]
        public void WhenIClearThePasswordField()
        {
            _loginPage.ClearPassword();
        }

        [Then("I should see the dashboard title {string}")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {
            var inventoryPage = _loginPage.LoginSuccessful();

            inventoryPage
                .IsPageUrlConsistent()
                .Should()
                .BeTrue();
            _logger.Info("Verified URL is consistent");

            inventoryPage
                .IsDashboardTitleDisplayed()
                .Should()
                .BeTrue();
            _logger.Info("Verified dashboard title is displayed");

            inventoryPage
                .GetDashboardTitle()
                .Should()
                .Be(expectedTitle);
            _logger.Info("Verified dashboard title matches expected value");
        }
    }
}
