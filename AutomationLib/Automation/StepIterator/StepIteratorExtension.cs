using AutomationLib.Automation.Step;

namespace AutomationLib.Automation.StepIterator
{
    public static class StepIteratorExtension
    {
        public static StepIterator Click(this StepIterator iterator, ElementIdentification identification)
        {
            var step = new ClickStep(identification);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator ElementExists(this StepIterator iterator, ElementIdentification identification, Action<bool> stepAction)
        {
            var step = new ElementExistsStep(identification, stepAction);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator ForEachElement(this StepIterator iterator, ElementIdentification identification, Action<int> stepAction)
        {
            var step = new ForEachElementStep(identification, stepAction);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator GetAttribute(this StepIterator iterator, ElementIdentification identification, string name, Action<string> stepAction)
        {
            var step = new GetAttributeStep(identification, name, stepAction);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator GetText(this StepIterator iterator, ElementIdentification identification, Action<string> stepAction)
        {
            var step = new GetTextStep(identification, stepAction);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator OpenUrl(this StepIterator iterator, string url)
        {
            var step = new OpenUrlStep(url);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator SetValue(this StepIterator iterator, ElementIdentification identification, string value)
        {
            var step = new SetValueStep(identification, value);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator SendKey(this StepIterator iterator, ElementIdentification identification, ConsoleKey key)
        {
            var step = new SendKeyStep(identification, key);
            return CreateNextIterator(iterator, step);
        }

        public static StepIterator Try (this StepIterator iterator, Action<StepIterator> actionToTry, Action<Exception, StepIterator> onErrorAction)
        {
            var step = new TryStep(actionToTry, onErrorAction);
            return CreateNextIterator(iterator, step);
        }
        public static StepIterator WaitForElement(this StepIterator iterator, ElementIdentification identification, TimeSpan timeToWait)
        {
            var step = new WaitForElementStep(identification, timeToWait);
            return CreateNextIterator(iterator, step);
        }

        private static StepIterator CreateNextIterator(StepIterator iterator, IStep step)
        {
            var item = new StepIterator(step);

            iterator.Append(item);

            return iterator;
        }        
    }
}
