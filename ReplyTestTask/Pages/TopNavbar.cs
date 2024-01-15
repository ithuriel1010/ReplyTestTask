using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReplyTestTask.Pages
{
    public class TopNavbar
    {
        private IWebDriver driver;
        private Helpers helpers;
        By salesAndMarketingTile = By.Id("grouptab-1");
        By reportsAndSettingsTile = By.Id("grouptab-5");
        By contactsSublink = By.XPath("//a[@class='menu-tab-sub-list' and text()=' Contacts']");
        By reportsSublink = By.XPath("//a[@class='menu-tab-sub-list' and text()=' Reports']");
        public TopNavbar(IWebDriver driver)
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }

        public ContactsPage OpenContractsPage()
        {
            driver.FindElement(salesAndMarketingTile).Click();
            helpers.WaitForElementClickable(contactsSublink);
            driver.FindElement(contactsSublink).Click();
            helpers.WaitForURLContaining("module=Contacts");

            return new ContactsPage(driver);
        }
        public ReportsPage OpenReportsPage()
        {
            driver.FindElement(reportsAndSettingsTile).Click();
            helpers.WaitForElementClickable(reportsSublink);
            driver.FindElement(reportsSublink).Click();
            helpers.WaitForURLContaining("module=Reports");

            return new ReportsPage(driver);
        }
    }
}
