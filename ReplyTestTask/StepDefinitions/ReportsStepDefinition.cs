using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Reports")]
    public class ReportsStepDefinition : BasicStepDefinition
    {
        private TopNavbar _topNavbar;
        private ReportsPage _reportsPage;
        private readonly string _reportName = "Project Profitability";

        public ReportsStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext){}

        [When(@"Navigate to Reports")]
        public void WhenNavigateToReports()
        {
            _topNavbar = new TopNavbar(_driver);
            _reportsPage = _topNavbar.OpenReportsPage();
        }

        [When(@"Find report")]
        public void WhenFindReport() => _reportsPage.SearchForReport(_reportName);

        [When(@"Run report")]
        public void WhenRunReport() => _reportsPage.OpenReport(_reportName).RunReport();

        [Then(@"Check results")]
        public void ThenCheckResults() => _reportsPage.CheckIfReportResultsAreDisplayed();
    }
}
