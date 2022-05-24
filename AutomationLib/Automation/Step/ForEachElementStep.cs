using AutomationLib.Automation.Step;

namespace AutomationLib.Automation
{
    public class ForEachElementStep : ElementStep
    {
        public Action<int> StepAction { get; }

        public ForEachElementStep(ElementIdentification element, Action<int> stepAction) : base(element)
        {
            StepAction = stepAction;
        }
    }
}
