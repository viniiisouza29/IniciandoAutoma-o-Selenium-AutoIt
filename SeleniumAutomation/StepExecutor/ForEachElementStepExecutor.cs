using AutomationLib.Automation;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class ForEachElementStepExecutor : StepExecutorBase<ForEachElementStep>
    {
        public override void ExecuteStep(ForEachElementStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();

            WaitForElement(driver, by, configuration);

            var elements = driver.FindElements(by);
            foreach (var element in elements)
            {
                step.StepAction(elements.IndexOf(element));
            }
        }
    }
}
