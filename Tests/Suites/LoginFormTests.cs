using Business.Abstractions;
using Business.Pages;
using Core;
using Core.Adapters;
using Core.WebDriver;
using Core.WebDriver.Factories;
using FluentAssertions;
using NLog;

namespace Tests.Suites
{
    [TestClass]
    public sealed class LoginFormTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            var _cfg = ConfigurationProvider.Tests;
            var _logger = LogManager.GetLogger("123");
            var webDriverFactory = new WebDriverFactory(_cfg.BrowserType);

            _logger.Info("Initializing WebDriver...");
            WebDriverManager.SetFactory(webDriverFactory);

            PageConfiguration.BaseUrl = _cfg.BaseUrl;
            PageConfiguration.LocatorProvider = new LocatorProvider();
            PageConfiguration.Logger = new LoggerAdapter(_logger);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            WebDriverManager.Instance.Configure();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            WebDriverManager.Instance.Quit();
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC1_Data), typeof(DataProvider))]
        public void UC1_LoginWithEmptyCredentials_ShowsUsernameRequired(string username, string password)
        {
            string expectedErrorMessage = "Username is required";

            var loginPage = new LoginPage(new WebDriverPageAdapter(WebDriverManager.Instance))
                .Open()
                .EnterCridentials(username, password)
                .ClearUsername()
                .ClearPassword()
                .ClickLogin();

            loginPage
                .IsPageUrlConsistent()
                .Should()
                .BeTrue();

            loginPage
                .IsErrorMessageDisplayed()
                .Should()
                .BeTrue();

            loginPage
                .GetErrorMessage()
                .Should()
                .Contain(expectedErrorMessage);
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC2_Data), typeof(DataProvider))]
        public void UC2_LoginWithEmptyPassword_ShowsPasswordRequired(string username, string password)
        {
            string expectedErrorMessage = "Password is required";

            var loginPage = new LoginPage(new WebDriverPageAdapter(WebDriverManager.Instance))
                .Open()
                .EnterCridentials(username, password)
                .ClearPassword()
                .ClickLogin();

            loginPage
                .IsPageUrlConsistent()
                .Should()
                .BeTrue();

            loginPage
                .IsErrorMessageDisplayed()
                .Should()
                .BeTrue();

            loginPage
                .GetErrorMessage()
                .Should()
                .Contain(expectedErrorMessage);
        }

        [DataTestMethod]
        [DynamicData(nameof(DataProvider.LoginForm_UC3_Data), typeof(DataProvider))]
        public void UC3_LoginWithValidCredentials_DisplaysDashboardWithValidTitle(string username, string password)
        {
            string expectedTitle = "Swag Labs";

            var inventoryPage = new LoginPage(new WebDriverPageAdapter(WebDriverManager.Instance))
                .Open()
                .EnterCridentials(username, password)
                .ClickLogin()
                .LoginSuccessful();

            inventoryPage
                .IsPageUrlConsistent()
                .Should()
                .BeTrue();

            inventoryPage
                .IsDashboardTitleDisplayed()
                .Should()
                .BeTrue();

            inventoryPage
                .GetDashboardTitle()
                .Should()
                .Be(expectedTitle);
        }
    }
}
