using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class ActivityLogPage
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;
        private readonly By _activityCheckmark = By.XPath("//tr[contains(@class,'listViewRow')]/td/div/input[@type='checkbox']");
        private readonly By _activitiesStatus = By.CssSelector(".listview-status");
        private readonly By _actionButton = By.XPath("//button[contains(@id,'ActionButtonFoot')]");
        private readonly By _deleteAction =
            By.XPath("//div[contains(@id,'ActionButtonFoot-popup')]/div/div/div[contains(@class,'option-cell') and text()='Delete']\r\n");

        public ActivityLogPage(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }

        public ActivityLogPage SelectFirstActivities(int number) 
        {
            var activities = _driver.FindElements(_activityCheckmark);
            var activitiesToSelect = activities.Take(number);
            foreach (var activity in activitiesToSelect) 
            {
                activity.Click();
            }
            return this;
        }
        public int CheckActivityCount()
        {
            int count = 0;
            string status = _driver.FindElement(_activitiesStatus).Text;

            string[] words = status.Split(' ');
            string number = words[words.Length - 1];
            if(number.Contains(","))
            {
                string fullNumber = number.Replace(','.ToString(), string.Empty);
                count = int.Parse(fullNumber);
            }
            else
            {
                count = int.Parse(number);
            }
            return count;
        }
        public ActivityLogPage DeleteSelectedActivities()
        {
            _helpers.WaitForElementClickable(_actionButton);
            _driver.FindElement(_actionButton).Click();
            _helpers.WaitForElementClickable(_deleteAction);
            _driver.FindElement(_deleteAction).Click();
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
            _helpers.WaitForElementWithText(_activitiesStatus, " Selected: 0 of");
            return this;
        }
    }
}
