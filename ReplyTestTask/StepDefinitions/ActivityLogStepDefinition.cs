using NUnit.Framework;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "ActivityLog")]
    public class ActivityLogStepDefinition : BasicStepDefinition
    {
        private TopNavbar _topNavbar;
        private ActivityLogPage _activityLogPage;
        private int activityNumberBeforeDelete = 0;

        public ActivityLogStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext) {}

        [When(@"Navigate to Activity Log")]
        public void WhenNavigateToReports()
        {
            _topNavbar = new TopNavbar(_driver);
            _activityLogPage = _topNavbar.OpenActivityLogPage();
        }

        [When(@"Select first (.*) items")]
        public void WhenSelectFirstItems(int number) => _activityLogPage.SelectFirstActivities(number);

        [When(@"Delete selected actions")]
        public void WhenDeleteSelectedActions()
        {
            activityNumberBeforeDelete = _activityLogPage.CheckActivityCount();
            _activityLogPage.DeleteSelectedActivities();
        }

        [Then(@"Check if (.*) items were deleted")]
        public void ThenCheckIfItemsWereDeleted(int number)
        {
            int activityNumberAfterDelete = _activityLogPage.CheckActivityCount();
            int deletedActivities = activityNumberBeforeDelete - activityNumberAfterDelete;
            Assert.AreEqual(number, deletedActivities, "The actual value is not equal to the expected value.");
        }
    }
}
