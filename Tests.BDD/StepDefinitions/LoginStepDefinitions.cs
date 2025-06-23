using Business.Abstractions;
using Business.Pages;
using Core;
using Core.Adapters;
using Core.WebDriver;
using Core.WebDriver.Factories;
using FluentAssertions;

namespace Tests.BDD.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions()
        {
            _loginPage = new LoginPage(new WebDriverPageAdapter(WebDriverManager.Instance));
        }

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            var _cfg = ConfigurationProvider.Tests;
            var webDriverFactory = new WebDriverFactory(_cfg.BrowserType);

            WebDriverManager.SetFactory(webDriverFactory);
            PageConfiguration.BaseUrl = _cfg.BaseUrl;
            PageConfiguration.LocatorProvider = new LocatorProvider();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            WebDriverManager.Instance.Quit();
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.Open();
        }

        [When("I enter (.*) and (.*)")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When("I clear the username and password fields")]
        public void WhenIClearTheUsernameAndPasswordFields()
        {
            _loginPage.ClearUsername();
            _loginPage.ClearPassword();
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then("I should see the error message {string}")]
        public void ThenIShouldSeeTheErrorMessage(string expectedErrorMessage)
        {
            var errorMessage = _loginPage.GetErrorMessage();
            errorMessage.Should().Contain(expectedErrorMessage);
        }

        [When("I clear the password field")]
        public void WhenIClearThePasswordField()
        {
            _loginPage.ClearPassword();
        }

        [Then("I should see the dashboard title {string}")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {
           var dashboardTitle = _loginPage
                .LoginSuccessful()
                .GetDashboardTitle();
            dashboardTitle.Should().Be(expectedTitle);
        }
    }
}
