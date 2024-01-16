using NUnit.Framework;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "ActivityLog")]
    public class ActivityLogStepDefinition : BasicStepDefinition
    {
        TopNavbar topNavbar;
        ActivityLogPage activityLogPage;
        private int activityNumberBeforeDelete = 0;

        public ActivityLogStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext) {}

        [When(@"Navigate to Activity Log")]
        public void WhenNavigateToReports()
        {
            topNavbar = new TopNavbar(_driver);
            activityLogPage = topNavbar.OpenActivityLogPage();
        }

        [When(@"Select first (.*) items")]
        public void WhenSelectFirstItems(int number) => activityLogPage.SelectFirstActivities(number);

        [When(@"Delete selected actions")]
        public void WhenDeleteSelectedActions()
        {
            activityNumberBeforeDelete = activityLogPage.CheckActivityCount();
            activityLogPage.DeleteSelectedActivities();
        }

        [Then(@"Check if (.*) items were deleted")]
        public void ThenCheckIfItemsWereDeleted(int number)
        {
            int activityNumberAfterDelete = activityLogPage.CheckActivityCount();
            int deletedActivities = activityNumberBeforeDelete - activityNumberAfterDelete;
            Assert.AreEqual(number, deletedActivities, "The actual value is not equal to the expected value.");
        }
    }
}
