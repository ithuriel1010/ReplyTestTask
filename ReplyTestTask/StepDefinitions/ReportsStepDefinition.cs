using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReplyTestTask.Drivers;
using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Reports")]
    public sealed class ReportsStepDefinition : BasicStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        TopNavbar topNavbar;
        ReportsPage reportsPage;
       
        public ReportsStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"Navigate to Reports")]
        public void WhenNavigateToReports()
        {
            topNavbar = new TopNavbar(driver);
            reportsPage = topNavbar.OpenReportsPage();
        }

        [When(@"Find report")]
        public void WhenFindReport()
        {
            reportsPage.SearchForReport("Project Profitability");
        }

        [When(@"Run report")]
        public void WhenRunReport()
        {
            string reportName = "Project Profitability";
            reportsPage.OpenReport(reportName).RunReport();
        }

        [Then(@"Check results")]
        public void ThenCheckResults()
        {
            reportsPage.CheckIfReportResultsAreDisplayed();
        }


    }
}
