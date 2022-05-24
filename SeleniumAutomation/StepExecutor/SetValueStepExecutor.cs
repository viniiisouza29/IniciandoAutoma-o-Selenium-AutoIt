using AutomationLib.Automation;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class SetValueStepExecutor : StepExecutorBase<SetValueStep>
    {
        public override void ExecuteStep(SetValueStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            var element = driver.FindElement(by);
            element.SendKeys(step.Value);
        }
    }
}