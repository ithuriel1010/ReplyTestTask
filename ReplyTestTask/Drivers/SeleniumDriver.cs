using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReplyTestTask.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {
            _driver = new ChromeDriver();
            _scenarioContext.Set(_driver, "WebDriver");

            _driver.Manage().Window.Maximize();
            return _driver;  
        }
    }
}
