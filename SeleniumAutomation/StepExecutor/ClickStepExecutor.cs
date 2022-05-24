using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class ClickStepExecutor : StepExecutorBase<ClickStep>
    {
        public override void ExecuteStep(ClickStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            var element = driver.FindElement(by);
            element.Click();
        }
    }
}