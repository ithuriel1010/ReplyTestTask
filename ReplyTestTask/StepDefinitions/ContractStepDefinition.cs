using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReplyTestTask.Drivers;
using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    public sealed class ContractStepDefinition
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        LoginPage loginPage;
        TopNavbar topNavbar;
        ContactsPage contactsPage;
        Contact contact = new Contact("Mark", "Green", "Sales", new List<string> { "Customers", "Suppliers" });

        public ContractStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login")]
        public void GivenLogin()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            loginPage = new LoginPage(driver);
            topNavbar = loginPage.Login("admin", "admin");
        }

        [When(@"Navigate to Contacts")]
        public void WhenNavigateToContacts()
        {
            contactsPage = topNavbar.OpenContractsPage(driver);
        }

        [When(@"Create new contact")]
        public void WhenCreateNewContact()
        {
            contactsPage.CreateContact(contact);
        }

        [When(@"Open created contact")]
        public void WhenOpenCreatedContact()
        {
            contactsPage = topNavbar.OpenContractsPage(driver);
            contactsPage.SearchForContact(contact).OpenContact(contact);
        }

        [Then(@"Contract data matches")]
        public void ThenContractDataMatches()
        {
            contactsPage.CheckContactInfo(contact);
        }

    }
}
