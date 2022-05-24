namespace AutomationLib.Automation.Step
{
    public class ElementExistsStep : ElementStep
    {
        public Action<bool> StepAction { get; }

        public ElementExistsStep(ElementIdentification element, Action<bool> stepAction) : base(element)
        {
            StepAction = stepAction;
        }
    }
}
