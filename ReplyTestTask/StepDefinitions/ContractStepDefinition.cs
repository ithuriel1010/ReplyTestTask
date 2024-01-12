using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReplyTestTask.Drivers;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    public sealed class ContractStepDefinition
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public ContractStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login")]
        public void GivenLogin()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
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
