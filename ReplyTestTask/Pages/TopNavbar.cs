using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class TopNavbar
    {
        private IWebDriver driver;
        private Helpers helpers;
        By salesAndMarketingTile = By.Id("grouptab-1");
        By reportsAndSettingsTile = By.Id("grouptab-5");
        By tileSublink(string subpageName) => By.XPath($"//a[@class='menu-tab-sub-list' and text()=' {subpageName}']");
        public TopNavbar(IWebDriver driver)
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }
        public ContactsPage OpenContractsPage()
        {
            helpers.WaitForElementClickable(salesAndMarketingTile);
            driver.FindElement(salesAndMarketingTile).Click();
            helpers.WaitForElementClickable(tileSublink("Contacts"));
            driver.FindElement(tileSublink("Contacts")).Click();
            helpers.WaitForURLContaining("module=Contacts");

            return new ContactsPage(driver);
        }
        public ReportsPage OpenReportsPage()
        {
            helpers.WaitForElementClickable(reportsAndSettingsTile);
            driver.FindElement(reportsAndSettingsTile).Click();
            helpers.WaitForElementClickable(tileSublink("Reports"));
            driver.FindElement(tileSublink("Reports")).Click();
            helpers.WaitForURLContaining("module=Reports");

            return new ReportsPage(driver);
        }
        public ActivityLogPage OpenActivityLogPage()
        {
            helpers.WaitForElementClickable(reportsAndSettingsTile);
            driver.FindElement(reportsAndSettingsTile).Click();
            helpers.WaitForElementClickable(tileSublink("Activity Log"));
            driver.FindElement(tileSublink("Activity Log")).Click();
            helpers.WaitForURLContaining("module=ActivityLog");

            return new ActivityLogPage(driver);
        }
    }
}
