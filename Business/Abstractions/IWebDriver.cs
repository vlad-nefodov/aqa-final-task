namespace Business.Abstractions;

public interface IWebDriver
{
    string Url { get; }

    bool IsDisplayed(Locator locator);

    string GetText(Locator locator);

    void NavigateTo(string url);

    void EnterText(Locator locator, string text);

    void ClearInput(Locator locator);

    void Click(Locator locator);
}