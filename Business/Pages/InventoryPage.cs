using Business.Abstractions;

namespace Business.Pages
{
    public class InventoryPage : BasePage<InventoryPage>
    {
        private readonly Locator _dashboardTitleLocator;

        protected override string PagePath => "/inventory.html";

        public InventoryPage(IWebDriver driver) : base(driver) 
        {
            _dashboardTitleLocator = LocatorProvider.XPath("//div[contains(@class, 'app_logo')]");
        }

        public string GetDashboardTitle()
        {
            return _driver.GetText(_dashboardTitleLocator);
        }

        public bool IsDashboardTitleDisplayed()
        {
            return _driver.IsDisplayed(_dashboardTitleLocator);
        }
    }
}
