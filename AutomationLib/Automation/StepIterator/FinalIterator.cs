using AutomationLib.Automation.Step;

namespace AutomationLib.Automation.StepIterator
{
    internal sealed class FinalIterator : IStepIterator
    {
        public IStep Step => throw new NotImplementedException();

        public void Append(IStepIterator stepIterator)
        {
            throw new NotImplementedException();
        }

        public IStepIterator GetNext()
        {
            throw new NotImplementedException();
        }

        public bool HasNext()
        {
            return false;
        }
    }
}
