using AutomationLib.Automation;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    public class OpenUrlStepExecutor : StepExecutorBase<OpenUrlStep>
    {
        public override void ExecuteStep(OpenUrlStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            driver.Navigate().GoToUrl(step.Url);
        }
    }
}