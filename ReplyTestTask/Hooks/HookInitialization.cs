using OpenQA.Selenium;
using ReplyTestTask.Drivers;
using TechTalk.SpecFlow;

namespace ReplyTestTask.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        private readonly ScenarioContext _scenarioContext;
        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}