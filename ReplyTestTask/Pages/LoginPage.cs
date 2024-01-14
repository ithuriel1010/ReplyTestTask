using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTestTask.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        By usernameField = By.Id("login_user");
        By passwordField = By.Id("login_pass");
        By loginButton = By.Id("login_button");

        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public TopNavbar Login(string username, string password)
        {
            driver.Url = "https://demo.1crmcloud.com";
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(loginButton).Click();    
            Thread.Sleep(2000);

            return new TopNavbar(driver);
        }
    }
}
