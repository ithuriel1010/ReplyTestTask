using OpenQA.Selenium;

namespace ReplyTestTask.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly Helpers _helpers;
        private readonly By _usernameField = By.Id("login_user");
        private readonly By _passwordField = By.Id("login_pass");
        private readonly By _loginButton = By.Id("login_button");

        public LoginPage(IWebDriver driver) 
        {
            _driver = driver;
            _helpers = new Helpers(_driver);
        }

        public TopNavbar Login()
        {
            string username = _helpers.GetSetUpProperty("Username");
            string password = _helpers.GetSetUpProperty("Password");
            string url = _helpers.GetSetUpProperty("BasicUrl");
            _driver.Url = url;
            _driver.FindElement(_usernameField).SendKeys(username);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_loginButton).Click();    

            return new TopNavbar(_driver);
        }
    }
}
