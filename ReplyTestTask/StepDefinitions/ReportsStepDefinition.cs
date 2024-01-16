using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Reports")]
    public class ReportsStepDefinition : BasicStepDefinition
    {
        TopNavbar topNavbar;
        ReportsPage reportsPage;
        string reportName = "Project Profitability";

        public ReportsStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext){}

        [When(@"Navigate to Reports")]
        public void WhenNavigateToReports()
        {
            topNavbar = new TopNavbar(_driver);
            reportsPage = topNavbar.OpenReportsPage();
        }

        [When(@"Find report")]
        public void WhenFindReport()
        {
            reportsPage.SearchForReport(reportName);
        }

        [When(@"Run report")]
        public void WhenRunReport()
        {
            reportsPage.OpenReport(reportName).RunReport();
        }

        [Then(@"Check results")]
        public void ThenCheckResults()
        {
            reportsPage.CheckIfReportResultsAreDisplayed();
        }
    }
}
