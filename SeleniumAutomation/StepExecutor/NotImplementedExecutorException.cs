using AutomationLib.Automation.Step;
using System.Runtime.Serialization;

namespace SeleniumAutomation.StepExecutor
{
    [Serializable]
    public class NotImplementedExecutorException : Exception
    {
        public IStep? Step { get; }

        public NotImplementedExecutorException(IStep step) : base($"Not implemented executor for Step type {step.GetType().Name}")
        {
            Step = step;
        }

        public NotImplementedExecutorException(Type type) : base($"Not implemented executor for Step type {type.Name}")
        {

        }

        protected NotImplementedExecutorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}