using System.Collections.ObjectModel;
using Core.WebDriver.Decorators.WebElementDecorators;
using OpenQA.Selenium;

namespace Core.WebDriver.Decorators;

internal class InjectExtendedWebElementDecorator : BaseWebDriverDecorator
{
    public InjectExtendedWebElementDecorator(IWebDriver driver) : base(driver)
    {
    }

    public override IWebElement FindElement(By by)
    {
        var element = base.FindElement(by);
        return new ClearInputValueWebElementDecorator(element);
    }

    public override ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        var elements = base
            .FindElements(by)
            .Select(el => new ClearInputValueWebElementDecorator(el))
            .Cast<IWebElement>()
            .ToList();

        return new ReadOnlyCollection<IWebElement>(elements);
    }
}