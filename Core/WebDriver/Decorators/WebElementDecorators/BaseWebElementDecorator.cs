using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Core.WebDriver.Decorators.WebElementDecorators;

public abstract class BaseWebElementDecorator : IWebElement
{
    protected readonly IWebElement _element;

    protected BaseWebElementDecorator(IWebElement element)
    {
        _element = element ?? throw new ArgumentNullException(nameof(element));
    }

    public virtual string TagName => _element.TagName;
    public virtual string Text => _element.Text;
    public virtual bool Enabled => _element.Enabled;
    public virtual bool Selected => _element.Selected;
    public virtual Point Location => _element.Location;
    public virtual Size Size => _element.Size;
    public virtual bool Displayed => _element.Displayed;

    public virtual void Clear()
    {
        _element.Clear();
    }

    public virtual void Click()
    {
        _element.Click();
    }

    public virtual IWebElement FindElement(By by)
    {
        return _element.FindElement(by);
    }

    public virtual ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _element.FindElements(by);
    }

    public virtual string? GetAttribute(string attributeName)
    {
        return _element.GetAttribute(attributeName);
    }

    public virtual string GetCssValue(string propertyName)
    {
        return _element.GetCssValue(propertyName);
    }

    public virtual string? GetDomAttribute(string attributeName)
    {
        return _element.GetDomAttribute(attributeName);
    }

    public virtual string? GetDomProperty(string propertyName)
    {
        return _element.GetDomProperty(propertyName);
    }

    public virtual ISearchContext GetShadowRoot()
    {
        return _element.GetShadowRoot();
    }

    public virtual void SendKeys(string text)
    {
        _element.SendKeys(text);
    }

    public virtual void Submit()
    {
        _element.Submit();
    }
}