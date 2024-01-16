using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class TopNavbar
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;
        private readonly By _salesAndMarketingTile = By.Id("grouptab-1");
        private readonly By _reportsAndSettingsTile = By.Id("grouptab-5");
        private static By TileSublink(string subpageName) => By.XPath($"//a[@class='menu-tab-sub-list' and text()=' {subpageName}']");
        public TopNavbar(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }
        public ContactsPage OpenContractsPage()
        {
            _helpers.WaitForElementClickable(_salesAndMarketingTile);
            _driver.FindElement(_salesAndMarketingTile).Click();
            _helpers.WaitForElementClickable(TileSublink("Contacts"));
            _driver.FindElement(TileSublink("Contacts")).Click();
            _helpers.WaitForURLContaining("module=Contacts");

            return new ContactsPage(_driver);
        }
        public ReportsPage OpenReportsPage()
        {
            _helpers.WaitForElementClickable(_reportsAndSettingsTile);
            _driver.FindElement(_reportsAndSettingsTile).Click();
            _helpers.WaitForElementClickable(TileSublink("Reports"));
            _driver.FindElement(TileSublink("Reports")).Click();
            _helpers.WaitForURLContaining("module=Reports");

            return new ReportsPage(_driver);
        }
        public ActivityLogPage OpenActivityLogPage()
        {
            _helpers.WaitForElementClickable(_reportsAndSettingsTile);
            _driver.FindElement(_reportsAndSettingsTile).Click();
            _helpers.WaitForElementClickable(TileSublink("Activity Log"));
            _driver.FindElement(TileSublink("Activity Log")).Click();
            _helpers.WaitForURLContaining("module=ActivityLog");

            return new ActivityLogPage(_driver);
        }
    }
}
