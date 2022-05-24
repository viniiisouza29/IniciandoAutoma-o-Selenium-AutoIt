namespace AutomationLib.Automation.Step
{
    public class TryStep : IStep
    {
        public Action<StepIterator.StepIterator> ActionToTry { get; }
        public Action<Exception, StepIterator.StepIterator> OnErrorAction { get; }

        public TryStep(Action<StepIterator.StepIterator> actionToTry, Action<Exception, StepIterator.StepIterator> onErrorAction)
        {
            ActionToTry = actionToTry;
            OnErrorAction = onErrorAction;
        }
    }
}
