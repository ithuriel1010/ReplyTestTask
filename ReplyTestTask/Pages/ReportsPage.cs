using NUnit.Framework;
using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class ReportsPage
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;
        private readonly By _searchField = By.Id("filter_text");
        private By _reportLink(string reportName) => By.XPath($"//a[@class='listViewNameLink' and text()='{reportName}']");
        private readonly By _runReportButton = By.XPath("//span[contains(@id,'FilterForm_applyButton-label') and text()='Run Report']");
        private readonly By _reportResultsTable = By.XPath("//table[contains(@id,'listView')]");

        public ReportsPage(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }

        public ReportsPage SearchForReport(string reportName) 
        {
            Thread.Sleep(5000); //page refreshes itself

            _driver.FindElement(_searchField).SendKeys($"{reportName} {Keys.Enter}");
            _helpers.WaitForElementClickable(_reportLink(reportName));
            return this;
        }
        public ReportsPage OpenReport(string reportName)
        {
            _helpers.WaitForElementClickable(_reportLink(reportName));
            _driver.FindElement(_reportLink(reportName)).Click();
            return this;
        }
        public ReportsPage RunReport()
        {
            Thread.Sleep(2000); //Waiting for element to be clickable is not enough, button is not clicked after the wait
            _helpers.WaitForElementClickable(_runReportButton);
            _driver.FindElement(_runReportButton).Click();   
            return this;
        }
        public ReportsPage CheckIfReportResultsAreDisplayed()
        {
            _helpers.WaitForElementVisible(_reportResultsTable);
            Assert.True(_driver.FindElement(_reportResultsTable).Displayed);
            return this;
        }


    }
}
