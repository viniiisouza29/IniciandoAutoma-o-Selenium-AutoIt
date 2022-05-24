using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    internal class ElementExistsStepExecutor : StepExecutorBase<ElementExistsStep>
    {
        public override void ExecuteStep(ElementExistsStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            var encontrado = true;

            try
            {
                var by = step.Element.ToSeleniumBy();
                WaitForElement(driver, by, configuration);
            }
            catch (NoSuchElementException)
            {
                encontrado = false;
            }
            finally
            {
                step.StepAction(encontrado);
            }
        }
    }
}
