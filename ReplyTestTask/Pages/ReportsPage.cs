using NUnit.Framework;
using OpenQA.Selenium;
using ReplyTestTask.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTestTask.Pages
{
    public class ReportsPage
    {
        private IWebDriver driver;
        private Helpers helpers;
        By searchField = By.Id("filter_text");
        By reportLink(string reportName) => By.XPath($"//a[@class='listViewNameLink' and text()='{reportName}']");
        By runReportButton = By.XPath("//span[contains(@id,'FilterForm_applyButton-label') and text()='Run Report']");
        By reportResultsTable = By.XPath("//table[contains(@id,'listView')]");



        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }

        public ReportsPage SearchForReport(string reportName) 
        {
            Thread.Sleep(5000); //page refreshes itself

            driver.FindElement(searchField).SendKeys($"{reportName} {Keys.Enter}");
            helpers.WaitForElementClickable(reportLink(reportName));
            return this;
        }
        public ReportsPage OpenReport(string reportName)
        {
            helpers.WaitForElementClickable(reportLink(reportName));
            driver.FindElement(reportLink(reportName)).Click();
            return this;
        }
        public ReportsPage RunReport()
        {
            Thread.Sleep(5000);
            helpers.WaitForElementClickable(runReportButton);
            driver.FindElement(runReportButton).Click();   
            return this;
        }
        public ReportsPage CheckIfReportResultsAreDisplayed()
        {
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(reportResultsTable).Displayed);
            return this;
        }


    }
}
