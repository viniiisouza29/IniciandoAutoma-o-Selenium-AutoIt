namespace AutomationLib.Automation.Step
{
    public class GetTextStep : ElementStep
    {
        public Action<string> StepAction { get; }

        public GetTextStep(ElementIdentification element, Action<string> stepAction) : base(element)
        {
            StepAction = stepAction;
        }
    }
}
