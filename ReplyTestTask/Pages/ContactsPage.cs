using NUnit.Framework;
using OpenQA.Selenium;
using ReplyTestTask.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTestTask.Pages
{
    public class ContactsPage
    {
        private IWebDriver driver;
        private Helpers helpers;

        By createButton = By.XPath("//button[contains(@id, 'create')]");
        By firstNameInput = By.Id("DetailFormfirst_name-input");
        By lastNameInput = By.Id("DetailFormlast_name-input");
        By categoriesInput = By.Id("DetailFormcategories-input");
        By searchCategoriesInput = By.XPath("//div[@id='DetailFormcategories-input-search']//input[@class='input-text']");
        By roleInput = By.Id("DetailFormbusiness_role-input");
        By saveButton = By.Id("DetailForm_save-label");
        By searchField = By.Id("filter_text");
        By contactName = By.Id("_form_header");
        By bussinessRole = By.XPath("//div[contains(@class,'cell-business_role')]/div/div[@class='form-value']");
        By contactSummary = By.XPath("//ul[@class=\"summary-list\"]");
        By contactLinks = By.XPath("//a[@class='listViewNameLink']");

        public ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }

        public ContactsPage CreateContact(Contact contact) 
        {
            driver.FindElement(createButton).Click();
            helpers.WaitForElementClickable(firstNameInput);
            driver.FindElement(firstNameInput).SendKeys(contact.FirstName);
            driver.FindElement(lastNameInput).SendKeys(contact.LastName);
            foreach (var category in contact.Categories)
            {
                Thread.Sleep(3000);
                driver.FindElement(categoriesInput).Click();    
                helpers.WaitForElementClickable(searchCategoriesInput);
                driver.FindElement(searchCategoriesInput).SendKeys(category);
                driver.FindElement(searchCategoriesInput).SendKeys(Keys.Enter);
            }
            driver.FindElement(roleInput).Click();
            driver.FindElement(By.XPath($"//div[@class='option-cell input-label ' and text()='{contact.Role}']"))
                .Click();
            driver.FindElement(saveButton).Click();
            Thread.Sleep(2000);
            return this;    
        }
        public ContactsPage SearchForContact(Contact contact)
        {
            driver.FindElement(searchField).SendKeys($"{contact.FirstName} {contact.LastName} {Keys.Enter}");
            Thread.Sleep(3000);
            return this;
        }

        public ContactsPage OpenContact(Contact contact)
        {
            driver.FindElement(By.XPath($"//a[@class='listViewNameLink' and text()='{contact.FirstName} {contact.LastName}']")).Click();

            return this;
        }
        public ContactsPage CheckContactInfo(Contact contact) 
        {
            helpers.WaitForElementVisible(contactName);

            Assert.AreEqual((contact.FirstName + " " + contact.LastName), driver.FindElement(contactName).Text.Trim(' '));
            Assert.IsTrue(driver.FindElement(bussinessRole).Text.Equals(contact.Role), 
                driver.FindElement(bussinessRole).Text + $" doesn't contains {contact.Role}");

            foreach (var category in contact.Categories)
            {
                Assert.IsTrue(driver.FindElement(contactSummary).Text.Contains(category),
                    driver.FindElement(contactSummary).Text + $" doesn't contains {category}");
            }

            return this;
        }
    }
}
