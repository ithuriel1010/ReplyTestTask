using OpenQA.Selenium;
using ReplyTestTask.Drivers;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    public class BasicStepDefinition
    {
        protected IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private LoginPage _loginPage;

        public BasicStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login")]
        public void GivenLogin()
        {
            _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            _loginPage = new LoginPage(_driver);
            _loginPage.Login();
        }
    }
}
