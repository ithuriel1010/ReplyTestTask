using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Contacts")]
    public class ContactStepDefinition:BasicStepDefinition
    {
        TopNavbar topNavbar;
        ContactsPage contactsPage;
        Contact contact = new("Mark", "Green", "Sales", new List<string> { "Customers", "Suppliers" });

        public ContactStepDefinition(ScenarioContext scenarioContext): base(scenarioContext) {}

        [When(@"Navigate to Contacts")]
        public void WhenNavigateToContacts()
        {
            topNavbar = new TopNavbar(_driver);
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
