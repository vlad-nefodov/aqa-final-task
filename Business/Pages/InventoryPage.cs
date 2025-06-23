using Business.Abstractions;

namespace Business.Pages;

public class InventoryPage : BasePage<InventoryPage>
{
    private readonly Locator _dashboardTitleLocator;

    public InventoryPage(IWebDriver driver) : base(driver)
    {
        _dashboardTitleLocator = LocatorProvider.XPath("//div[contains(@class, 'app_logo')]");
    }

    protected override string PagePath => "/inventory.html";

    public string GetDashboardTitle()
    {
        return Driver.GetText(_dashboardTitleLocator);
    }

    public bool IsDashboardTitleDisplayed()
    {
        return Driver.IsDisplayed(_dashboardTitleLocator);
    }
}