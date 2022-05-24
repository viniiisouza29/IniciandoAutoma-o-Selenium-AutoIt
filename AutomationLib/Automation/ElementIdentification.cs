namespace AutomationLib.Automation
{
    public class ElementIdentification
    {
        public IdentificationType IdentificationType { get; }
        public string IdentificationValue { get; }

        public ElementIdentification(IdentificationType identificationType, string value)
        {
            IdentificationType = identificationType;
            IdentificationValue = value;
        }
    }
}
