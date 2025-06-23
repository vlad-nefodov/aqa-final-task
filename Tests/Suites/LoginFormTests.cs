using Business.Abstractions;
using Business.Pages;
using Core;
using Core.Adapters;
using Core.WebDriver;
using Core.WebDriver.Factories;
using FluentAssertions;
using NLog;
using ILogger = NLog.ILogger;

namespace Tests.Suites;

[TestClass]
public sealed class LoginFormTests
{
    private static ILogger _logger;
    private IWebDriver _pageDriver;

    [ClassInitialize]
    public static void ClassInitialize(TestContext _)
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

    [TestInitialize]
    public void TestInitialize()
    {
        _logger.Info("Configuting WebDriver...");
        _pageDriver = new WebDriverPageAdapter(WebDriverManager.Instance);
        WebDriverManager.Instance.Configure(5);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        WebDriverManager.Instance.Quit();
        _logger.Info("Closed WebDriver");
    }

    [DataTestMethod]
    [DynamicData(nameof(DataProvider.LoginFormUc1Data), typeof(DataProvider))]
    public void UC1_LoginWithEmptyCredentials_ShowsUsernameRequired(string username, string password)
    {
        _logger.Info($"[UC1] Starting test with username: '{username}' and password: '{password}'");
        const string expectedErrorMessage = "Username is required";

        var loginPage = new LoginPage(_pageDriver)
            .Open()
            .EnterCredentials(username, password)
            .ClearUsername()
            .ClearPassword()
            .ClickLogin();
        _logger.Info("[UC1] Performed login with cleared credentials");

        loginPage
            .IsPageUrlConsistent()
            .Should()
            .BeTrue();
        _logger.Info("[UC1] Verified URL is consistent");

        loginPage
            .IsErrorMessageDisplayed()
            .Should()
            .BeTrue();
        _logger.Info("[UC1] Verified error message is displayed");

        loginPage
            .GetErrorMessage()
            .Should()
            .Contain(expectedErrorMessage);
        _logger.Info("[UC1] Verified error message contains expected text");
    }

    [DataTestMethod]
    [DynamicData(nameof(DataProvider.LoginFormUc2Data), typeof(DataProvider))]
    public void UC3_LoginWithEmptyPassword_ShowsPasswordRequired(string username, string password)
    {
        _logger.Info($"[UC2] Starting test with username: '{username}' and password: '{password}'");
        const string expectedErrorMessage = "Password is required";

        var loginPage = new LoginPage(_pageDriver)
            .Open()
            .EnterCredentials(username, password)
            .ClearPassword()
            .ClickLogin();
        _logger.Info("[UC2] Performed login with empty password");

        loginPage
            .IsPageUrlConsistent()
            .Should()
            .BeTrue();
        _logger.Info("[UC2] Verified URL is consistent");

        loginPage
            .IsErrorMessageDisplayed()
            .Should()
            .BeTrue();
        _logger.Info("[UC2] Verified error message is displayed");

        loginPage
            .GetErrorMessage()
            .Should()
            .Contain(expectedErrorMessage);
        _logger.Info("[UC2] Verified error message contains expected text");
    }

    [DataTestMethod]
    [DynamicData(nameof(DataProvider.LoginFormUc3Data), typeof(DataProvider))]
    public void UC3_LoginWithValidCredentials_DisplaysDashboardWithValidTitle(string username, string password)
    {
        _logger.Info($"[UC3] Starting test with valid username: '{username}' and password: '{password}'");

        const string expectedTitle = "Swag Labs";

        var inventoryPage = new LoginPage(_pageDriver)
            .Open()
            .EnterCredentials(username, password)
            .ClickLogin()
            .LoginSuccessful();
        _logger.Info("[UC3] Performed successful login");

        inventoryPage
            .IsPageUrlConsistent()
            .Should()
            .BeTrue();
        _logger.Info("[UC3] Verified URL is consistent");

        inventoryPage
            .IsDashboardTitleDisplayed()
            .Should()
            .BeTrue();
        _logger.Info("[UC3] Verified dashboard title is displayed");

        inventoryPage
            .GetDashboardTitle()
            .Should()
            .Be(expectedTitle);
        _logger.Info("[UC3] Verified dashboard title matches expected value");
    }
}