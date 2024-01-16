using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Contacts")]
    public class ContactStepDefinition:BasicStepDefinition
    {
        private TopNavbar _topNavbar;
        private ContactsPage _contactsPage;
        private readonly Contact _contact = new("Mark", "Green", "Sales", new List<string> { "Customers", "Suppliers" });

        public ContactStepDefinition(ScenarioContext scenarioContext): base(scenarioContext) {}

        [When(@"Navigate to Contacts")]
        public void WhenNavigateToContacts()
        {
            _topNavbar = new TopNavbar(_driver);
            _contactsPage = _topNavbar.OpenContractsPage();
        }

        [When(@"Create new contact")]
        public void WhenCreateNewContact() => _contactsPage.CreateContact(_contact);

        [When(@"Open created contact")]
        public void WhenOpenCreatedContact()
        {
            _contactsPage = _topNavbar.OpenContractsPage();
            _contactsPage.SearchForContact(_contact).OpenContact(_contact);
        }

        [Then(@"Contract data matches")]
        public void ThenContractDataMatches() => _contactsPage.CheckContactInfo(_contact);
    }
}
