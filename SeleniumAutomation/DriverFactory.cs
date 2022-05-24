using AutomationLib.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumAutomation
{
    internal static class DriverFactory
    {
        internal static IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    return new FirefoxDriver();

                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver();

                default:
                    return new ChromeDriver();
            }
        }
    }
}