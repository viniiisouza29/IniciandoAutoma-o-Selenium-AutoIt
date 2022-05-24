namespace AutomationLib.Automation
{
    public static class By
    {
        public static ElementIdentification Name(string value)
        {
            return new ElementIdentification(IdentificationType.Name, value);
        }

        public static ElementIdentification Id(string value)
        {
            return new ElementIdentification(IdentificationType.Id, value);
        }

        public static ElementIdentification XPath(string value)
        {
            return new ElementIdentification(IdentificationType.XPath, value);
        }
    }
}
