using NUnit.Framework;
using OpenQA.Selenium;

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
            Thread.Sleep(2000); //Waiting for element to be clickable is not enough, button is not clicked after the wait
            helpers.WaitForElementClickable(runReportButton);
            driver.FindElement(runReportButton).Click();   
            return this;
        }
        public ReportsPage CheckIfReportResultsAreDisplayed()
        {
            helpers.WaitForElementVisible(reportResultsTable);
            Assert.True(driver.FindElement(reportResultsTable).Displayed);
            return this;
        }


    }
}
