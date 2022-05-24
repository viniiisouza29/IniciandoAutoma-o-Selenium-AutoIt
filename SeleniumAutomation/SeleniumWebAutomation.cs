using AutomationLib.Automation;
using AutomationLib.Automation.StepIterator;
using OpenQA.Selenium;
using SeleniumAutomation.Configuration;
using SeleniumAutomation.StepExecutor;

namespace SeleniumAutomation
{
    public class SeleniumWebAutomation : IWebAutomation
    {
        private IWebDriver? _webDriver;
        private bool _disposed = false;
        private bool _stepDelayEnabled = true;

        private readonly SeleniumConfiguration _configuration;
        private readonly StepExecutorFactory _stepExecutorFactory;

        public SeleniumWebAutomation(SeleniumConfiguration configuration, StepExecutorFactory stepExecutorFactory)
        {
            _configuration = configuration;
            _stepExecutorFactory = stepExecutorFactory;
        }

        public void Execute(IStepIterator steps)
        {
            if(_webDriver == null)
                _webDriver = DriverFactory.Create(_configuration.BrowserType);

            do
            {
                steps = steps.GetNext();

                var stepExecutor = _stepExecutorFactory.Create(steps.Step);
                stepExecutor.Execute(_webDriver, _configuration);

                WaitATimeBetweenSteps();
            }
            while (steps.HasNext());
        }

        private void WaitATimeBetweenSteps()
        {
            if (_stepDelayEnabled)
                Thread.Sleep(_configuration.DefaultDelayBetweenSteps);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if(disposing)
                _webDriver?.Dispose();

            _webDriver = null;
            _disposed = true;
        }

        public void DisableStepDelay()
        {
            _stepDelayEnabled = false;
        }

        public void EnableStepDelay()
        {
            _stepDelayEnabled |= true;
        }

        ~SeleniumWebAutomation()
        {
            Dispose(false);
        }
    }
}