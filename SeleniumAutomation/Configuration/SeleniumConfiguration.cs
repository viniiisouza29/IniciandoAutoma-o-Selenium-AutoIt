using AutomationLib.Automation;

namespace SeleniumAutomation.Configuration
{
    public class SeleniumConfiguration
    {
        public TimeSpan DefaultTimeOut { get; init; }
        public TimeSpan DefaultDelayBetweenSteps { get; init; }
        public BrowserType BrowserType { get; init; }
    }
}