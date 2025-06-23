using OpenQA.Selenium;

namespace Core.WebDriver.Factories;

public interface IWebDriverFactory
{
    IWebDriver GetWebDriver();
}