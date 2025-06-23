using OpenQA.Selenium;

namespace Core.WebDriver.Decorators.WebElementDecorators;

public class ClearInputValueWebElementDecorator : BaseWebElementDecorator
{
    public ClearInputValueWebElementDecorator(IWebElement element) : base(element)
    {
    }

    public override void Clear()
    {
        var tagName = _element.TagName.ToLower();
        var type = _element.GetAttribute("type")?.ToLower();

        if (tagName == "input" && (type == "text" || type == "password"))
        {
            _element.SendKeys(Keys.Control + "a" + Keys.Backspace);
        }
        else
        {
            base.Clear();
        }
    }
}