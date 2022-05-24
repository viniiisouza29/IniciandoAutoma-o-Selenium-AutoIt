using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;
using System.Linq.Expressions;

namespace SeleniumAutomation.StepExecutor
{
    public class NoStepExecutor : StepExecutorBase<NoStep>
    {
        public override void ExecuteStep(NoStep step, IWebDriver driver, SeleniumConfiguration configuration) => Expression.Empty();
    }
}