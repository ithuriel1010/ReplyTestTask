using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;

namespace ReplyTestTask.Pages
{
    public class Helpers
    {
        private readonly WebDriverWait _wait;
        public Helpers(IWebDriver driver) 
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
        }

        public void WaitForElementClickable(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitForElementVisible(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitForElementWithText(By locator, string text)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }
        public void WaitForURLContaining(string urlFraagment)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(urlFraagment));
        }
        public string GetSetUpProperty(string property) 
        {
            var jsonFilePath = Path.Combine("Setup", "SetUp.json");
            var jsonContent = File.ReadAllText(jsonFilePath);
            
            var jsonDocument = JsonDocument.Parse(jsonContent);
            var root = jsonDocument.RootElement;
            return root.GetProperty(property).GetString();
        }
    }
}
