using AutomationLib.Automation.StepIterator;

namespace AutomationLib.Automation
{
    public interface IWebAutomation : IDisposable
    {
        void Execute(IStepIterator steps);
        void DisableStepDelay();
        void EnableStepDelay();
    }
}
