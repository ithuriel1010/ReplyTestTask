using OpenQA.Selenium;

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

            return new TopNavbar(driver);
        }
    }
}
