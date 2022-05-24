using AutomationLib.Automation.Step;

namespace AutomationLib.Automation.StepIterator
{
    public class StepIterator : IStepIterator
    {
        private IStepIterator _next = new FinalIterator();

        public IStep Step { get; private set; }

        public StepIterator()
        {
            Step = new NoStep();
        }

        public StepIterator(IStep step)
        {
            Step = step;
        }

        public void Append(IStepIterator stepIterator)
        {
            if (HasNext())
            {
                GetNext().Append(stepIterator);
            }
            else
            {
                _next = stepIterator;
            }
        }

        public IStepIterator GetNext()
        {
            return _next;
        }

        public bool HasNext()
        {
            return _next is not FinalIterator;
        }
    }
}
