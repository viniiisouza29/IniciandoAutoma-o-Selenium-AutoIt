using AutomationLib.Automation.Step;

namespace AutomationLib.Automation
{
    public class SetValueStep: ElementStep
    {
        public string Value { get; }

        public SetValueStep(ElementIdentification element, string value) : base(element)
        {
            Value = value;
        }
    }
}
