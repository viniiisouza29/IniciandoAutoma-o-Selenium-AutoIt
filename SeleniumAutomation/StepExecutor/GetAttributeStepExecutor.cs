using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class GetAttributeStepExecutor : StepExecutorBase<GetAttributeStep>
    {
        public override void ExecuteStep(GetAttributeStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            var element = driver.FindElement(by);
            var attribute = element.GetAttribute(step.Name);

            step.StepAction(attribute);
        }
    }
}
