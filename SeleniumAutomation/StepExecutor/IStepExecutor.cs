using AutomationLib.Automation.Step;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Configuration;

namespace SeleniumAutomation.StepExecutor
{
    public interface IStepExecutor<in T> : IStepExecutor, IStepExecutorSetup<T> where T : IStep
    { }

    public interface IStepExecutor
    {
        void Execute(IWebDriver driver, SeleniumConfiguration configuration);
    }

    public interface IStepExecutorSetup<in T>
    {
        void SetStep(T step);
    }

    public abstract class StepExecutorBase<T> : IStepExecutor<T> where T : IStep
    {
        protected T? _step;

        public abstract void ExecuteStep(T step, IWebDriver driver, SeleniumConfiguration configuration);

        public void Execute(IWebDriver driver, SeleniumConfiguration configuration)
        {
            if (_step == null)
                throw new NotImplementedExecutorException(typeof(T));

            ExecuteStep(_step, driver, configuration);
        }

        public void SetStep(T step)
        {
            _step = step;
        }

        protected void WaitForElement(IWebDriver driver, By by, SeleniumConfiguration configuration)
        {
            var w = new WebDriverWait(driver, configuration.DefaultTimeOut);
            w.Until(x => x.FindElement(by));
        }
    }
}