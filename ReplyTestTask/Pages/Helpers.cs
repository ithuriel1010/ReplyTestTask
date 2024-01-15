﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
    }
}
