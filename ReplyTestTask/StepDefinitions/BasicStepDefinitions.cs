using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReplyTestTask.Drivers;
using ReplyTestTask.Objects;
using ReplyTestTask.Pages;

namespace ReplyTestTask.StepDefinitions
{
    public class BasicStepDefinition
    {
        protected IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        LoginPage loginPage;
        TopNavbar topNavbar;

        public BasicStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Login")]
        public void GivenLogin()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            loginPage = new LoginPage(driver);
            loginPage.Login("admin", "admin");
        }

    }
}
