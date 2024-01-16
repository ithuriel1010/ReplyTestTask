using NUnit.Framework;
using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class ReportsPage
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;
        private readonly By _searchField = By.Id("filter_text");
        private readonly By _runReportButton = By.XPath("//span[contains(@id,'FilterForm_applyButton-label') and text()='Run Report']");
        private readonly By _reportResultsTable = By.XPath("//table[contains(@id,'listView')]");
        private static By ReportLink(string reportName) => By.XPath($"//a[@class='listViewNameLink' and text()='{reportName}']");

        public ReportsPage(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }

        public ReportsPage SearchForReport(string reportName) 
        {
            Thread.Sleep(5000); //page refreshes itself

            _driver.FindElement(_searchField).SendKeys($"{reportName} {Keys.Enter}");
            _helpers.WaitForElementClickable(ReportLink(reportName));
            return this;
        }
        public ReportsPage OpenReport(string reportName)
        {
            _helpers.WaitForElementClickable(ReportLink(reportName));
            _driver.FindElement(ReportLink(reportName)).Click();
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
