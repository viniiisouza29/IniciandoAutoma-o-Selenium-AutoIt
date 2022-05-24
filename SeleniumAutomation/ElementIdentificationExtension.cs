using AutomationLib.Automation;

namespace SeleniumAutomation
{
    public static class ElementIdentificationExtension
    {
        public static OpenQA.Selenium.By ToSeleniumBy(this ElementIdentification element)
        {
            switch (element.IdentificationType)
            {
                case IdentificationType.Id:
                    return OpenQA.Selenium.By.Id(element.IdentificationValue);
                case IdentificationType.Name:
                    return OpenQA.Selenium.By.Name(element.IdentificationValue);
                case IdentificationType.XPath:
                    return OpenQA.Selenium.By.XPath(element.IdentificationValue);
                default:
                    throw new ArgumentException(element.IdentificationValue.ToString());
            }
        }
    }
}