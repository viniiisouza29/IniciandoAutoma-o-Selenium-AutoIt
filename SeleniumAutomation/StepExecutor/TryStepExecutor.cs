using AutomationLib.Automation;
using AutomationLib.Automation.Step;
using AutomationLib.Automation.StepIterator;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.StepExecutor
{
    internal class TryStepExecutor : StepExecutorBase<TryStep>
    {
        private readonly IWebAutomation _webAutomation;

        public TryStepExecutor(IWebAutomation webAutomation)
        {
            _webAutomation = webAutomation;
        }

        public override void ExecuteStep(TryStep step, IWebDriver driver, SeleniumConfiguration configuration)
        {
            try
            {
                var iterator = new StepIterator();
                step.ActionToTry(iterator);

                _webAutomation.Execute(iterator);
            }
            catch(Exception ex)
            {
                var iterator = new StepIterator();
                step.OnErrorAction(ex, iterator);

                _webAutomation.Execute(iterator);
            }
        }
    }
}
