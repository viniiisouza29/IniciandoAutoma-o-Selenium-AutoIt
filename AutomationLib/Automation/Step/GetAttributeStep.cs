namespace AutomationLib.Automation.Step
{
    public class GetAttributeStep : ElementStep
    {
        public string Name { get; }
        public Action<string> StepAction { get; }

        public GetAttributeStep(ElementIdentification element, string name, Action<string> stepAction) : base(element)
        {
            Name = name;
            StepAction = stepAction;
        }
    }
}
