using AutomationLib.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class WaitForElementStepExecutor : StepExecutorBase<WaitForElementStep>
    {
        public override void ExecuteStep(WaitForElementStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var by = step.Element.ToSeleniumBy();
            var w = new WebDriverWait(driver, step.TimeToWait);
            w.Until(x => x.FindElement(by));
        }
    }
}