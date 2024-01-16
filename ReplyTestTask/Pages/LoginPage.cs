using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        Helpers helpers;
        By usernameField = By.Id("login_user");
        By passwordField = By.Id("login_pass");
        By loginButton = By.Id("login_button");

        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            helpers = new Helpers(driver);
        }

        public TopNavbar Login()
        {
            string username = helpers.GetSetUpProperty("Username");
            string password = helpers.GetSetUpProperty("Password");
            string url = helpers.GetSetUpProperty("BasicUrl");
            driver.Url = url;
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(loginButton).Click();    

            return new TopNavbar(driver);
        }
    }
}
