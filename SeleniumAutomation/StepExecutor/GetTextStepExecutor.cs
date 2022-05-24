using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class GetTextStepExecutor : StepExecutorBase<GetTextStep>
    {
        public override void ExecuteStep(GetTextStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            var element = driver.FindElement(by);

            step.StepAction(element.Text);
        }
    }
}
