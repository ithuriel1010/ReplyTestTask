using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class ActivityLogPage
    {
        private IWebDriver driver;
        private Helpers helpers;
        By activityCheckmark = By.XPath("//tr[contains(@class,'listViewRow')]/td/div/input[@type='checkbox']");
        By activitiesStatus = By.CssSelector(".listview-status");
        By actionButton = By.XPath("//button[contains(@id,'ActionButtonFoot')]");
        By deleteAction =
            By.XPath("//div[contains(@id,'ActionButtonFoot-popup')]/div/div/div[contains(@class,'option-cell') and text()='Delete']\r\n");

        public ActivityLogPage(IWebDriver driver)
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }

        public ActivityLogPage SelectFirstActivities(int number) 
        {
            var activities = driver.FindElements(activityCheckmark);
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
            string status = driver.FindElement(activitiesStatus).Text;

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
            helpers.WaitForElementClickable(actionButton);
            driver.FindElement(actionButton).Click();
            helpers.WaitForElementClickable(deleteAction);
            driver.FindElement(deleteAction).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            helpers.WaitForElementWithText(activitiesStatus, " Selected: 0 of");
            return this;
        }
    }
}
