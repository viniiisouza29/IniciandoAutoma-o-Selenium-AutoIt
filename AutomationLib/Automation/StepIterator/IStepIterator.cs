using AutomationLib.Automation.Step;

namespace AutomationLib.Automation.StepIterator
{
    public interface IStepIterator {
        IStep Step { get; }

        void Append(IStepIterator stepIterator);
        IStepIterator GetNext();
        bool HasNext();
    }
}
