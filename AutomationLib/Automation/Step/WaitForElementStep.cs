using AutomationLib.Automation.Step;

namespace AutomationLib.Automation
{
    public class WaitForElementStep : ElementStep
    {
        public TimeSpan TimeToWait { get; }

        public WaitForElementStep(ElementIdentification element, TimeSpan timeToWait) : base(element)
        {
            TimeToWait = timeToWait;
        }
    }
}
