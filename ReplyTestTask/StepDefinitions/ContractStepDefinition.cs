using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    public sealed class Test1
    {
        private IWebDriver driver;

        [Given(@"Login")]
        public void GivenLogin()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.1crmcloud.com";
        }

        [When(@"Navigate to Contacts")]
        public void WhenNavigateToContacts()
        {
            throw new PendingStepException();
        }

        [When(@"Create new contact")]
        public void WhenCreateNewContact()
        {
            throw new PendingStepException();
        }

        [When(@"Open created contact")]
        public void WhenOpenCreatedContact()
        {
            throw new PendingStepException();
        }

        [Then(@"Contract data matches")]
        public void ThenContractDataMatches()
        {
            throw new PendingStepException();
        }

    }
}
