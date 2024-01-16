using NUnit.Framework;
using OpenQA.Selenium;
using ReplyTestTask.Objects;

namespace ReplyTestTask.Pages
{
    public class ContactsPage
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;

        private readonly By _createButton = By.XPath("//button[contains(@id, 'create')]");
        private readonly By _firstNameInput = By.Id("DetailFormfirst_name-input");
        private readonly By _lastNameInput = By.Id("DetailFormlast_name-input");
        private readonly By _categoriesInput = By.Id("DetailFormcategories-input");
        private readonly By _searchCategoriesInput = By.XPath("//div[@id='DetailFormcategories-input-search']//input[@class='input-text']");
        private readonly By _roleInput = By.Id("DetailFormbusiness_role-input");
        private readonly By _saveButton = By.Id("DetailForm_save-label");
        private readonly By _searchField = By.Id("filter_text");
        private readonly By _contactName = By.Id("_form_header");
        private readonly By _bussinessRole = By.XPath("//div[contains(@class,'cell-business_role')]/div/div[@class='form-value']");
        private readonly By _contactSummary = By.XPath("//ul[@class=\"summary-list\"]");
        private static By RoleOption(string role) => By.XPath($"//div[@class='option-cell input-label ' and text()='{role}']");
        private static By ContactLink(string name) => By.XPath($"//a[@class='listViewNameLink' and text()='{name}']");

        public ContactsPage(IWebDriver driver)
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }

        public ContactsPage CreateContact(Contact contact) 
        {
            _driver.FindElement(_createButton).Click();
            _helpers.WaitForElementClickable(_firstNameInput);
            _driver.FindElement(_firstNameInput).SendKeys(contact.FirstName);
            _driver.FindElement(_lastNameInput).SendKeys(contact.LastName);
            foreach (var category in contact.Categories)
            {
                Thread.Sleep(3000);
                _driver.FindElement(_categoriesInput).Click();    
                _helpers.WaitForElementClickable(_searchCategoriesInput);
                _driver.FindElement(_searchCategoriesInput).SendKeys(category);
                _driver.FindElement(_searchCategoriesInput).SendKeys(Keys.Enter);
            }
            _driver.FindElement(_roleInput).Click();
            _driver.FindElement(RoleOption(contact.Role)).Click();
            _driver.FindElement(_saveButton).Click();
            Thread.Sleep(1000); //Contact not saved correctly if user moves to the next step without a pause

            return this;    
        }
        public ContactsPage SearchForContact(Contact contact)
        {
            _driver.FindElement(_searchField).SendKeys($"{contact.FirstName} {contact.LastName} {Keys.Enter}");
            Thread.Sleep(3000); //Time for search results to load
            return this;
        }
        public ContactsPage OpenContact(Contact contact)
        {
            _driver.FindElement(ContactLink($"{contact.FirstName} {contact.LastName}")).Click();
            return this;
        }
        public ContactsPage CheckContactInfo(Contact contact) 
        {
            _helpers.WaitForElementVisible(_contactName);

            Assert.AreEqual((contact.FirstName + " " + contact.LastName), _driver.FindElement(_contactName).Text.Trim(' '));
            Assert.IsTrue(_driver.FindElement(_bussinessRole).Text.Equals(contact.Role), 
                _driver.FindElement(_bussinessRole).Text + $" doesn't contains {contact.Role}");

            foreach (var category in contact.Categories)
            {
                Assert.IsTrue(_driver.FindElement(_contactSummary).Text.Contains(category),
                    _driver.FindElement(_contactSummary).Text + $" doesn't contains {category}");
            }
            return this;
        }
    }
}
