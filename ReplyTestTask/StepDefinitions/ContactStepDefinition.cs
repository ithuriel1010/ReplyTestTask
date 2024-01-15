using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Contacts")]
    public sealed class ContactStepDefinition:BasicStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        TopNavbar topNavbar;
        ContactsPage contactsPage;
        Contact contact = new Contact("Mark", "Green", "Sales", new List<string> { "Customers", "Suppliers" });

        public ContactStepDefinition(ScenarioContext scenarioContext): base(scenarioContext)
        {
           _scenarioContext = scenarioContext;
        }

        [When(@"Navigate to Contacts")]
        public void WhenNavigateToContacts()
        {
            topNavbar = new TopNavbar(driver);
            contactsPage = topNavbar.OpenContractsPage();
        }

        [When(@"Create new contact")]
        public void WhenCreateNewContact()
        {
            contactsPage.CreateContact(contact);
        }

        [When(@"Open created contact")]
        public void WhenOpenCreatedContact()
        {
            contactsPage = topNavbar.OpenContractsPage();
            contactsPage.SearchForContact(contact).OpenContact(contact);
        }

        [Then(@"Contract data matches")]
        public void ThenContractDataMatches()
        {
            contactsPage.CheckContactInfo(contact);
        }
    }
}
