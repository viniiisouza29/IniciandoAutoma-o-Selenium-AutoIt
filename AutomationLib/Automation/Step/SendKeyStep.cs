namespace AutomationLib.Automation.Step
{
    public class SendKeyStep : ElementStep
    {
        public ConsoleKeyInfo Key { get; }

        public SendKeyStep(ElementIdentification element, ConsoleKey key) : base(element)
        {
            Key = new ConsoleKeyInfo((char)key, key, false, false, false);
        }
    }
}
