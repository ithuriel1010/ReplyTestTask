using OpenQA.Selenium;
using ReplyTestTask.Drivers;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    public class BasicStepDefinition
    {
        protected IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        LoginPage loginPage;

        public BasicStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login")]
        public void GivenLogin()
        {
            _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            loginPage = new LoginPage(_driver);
            loginPage.Login();
        }
    }
}
