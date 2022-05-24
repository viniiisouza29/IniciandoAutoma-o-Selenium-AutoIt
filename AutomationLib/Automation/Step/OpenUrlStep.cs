using AutomationLib.Automation.Step;

namespace AutomationLib.Automation
{
    public struct OpenUrlStep : IStep
    {
        public string Url { get; }

        public OpenUrlStep(string url)
        {
            Url = url;
        }
    }
}
