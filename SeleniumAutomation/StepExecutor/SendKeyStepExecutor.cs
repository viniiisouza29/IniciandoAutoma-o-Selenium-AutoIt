using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class SendKeyStepExecutor : StepExecutorBase<SendKeyStep>
    {
        public override void ExecuteStep(SendKeyStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            driver.FindElement(by).SendKeys(step.Key.ToSeleniumKey());
        }
    }
}
