using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;

namespace ReplyTestTask.Pages
{
    public class Helpers
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Helpers(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
        }

        public void WaitForElementClickable(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitForElementVisible(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitForElementWithText(By locator, string text)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }
        public void WaitForURLContaining(string urlFraagment)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(urlFraagment));
        }
        public string GetSetUpProperty(string property) 
        {
            string result;
            string jsonFilePath = Path.Combine("Setup", "SetUp.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            
            JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
            JsonElement root = jsonDocument.RootElement;
            result = root.GetProperty(property).GetString();
            return result;
        }
    }
}
