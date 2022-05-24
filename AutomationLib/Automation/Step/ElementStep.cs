namespace AutomationLib.Automation.Step
{
    public class ElementStep : IStep
    {
        public ElementIdentification Element { get; }

        public ElementStep(ElementIdentification element)
        {
            Element = element;
        }
    }
}
