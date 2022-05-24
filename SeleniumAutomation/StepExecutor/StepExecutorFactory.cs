using AutomationLib.Automation;
using AutomationLib.Automation.Step;
using Microsoft.Extensions.DependencyInjection;

namespace SeleniumAutomation.StepExecutor
{
    public class StepExecutorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StepExecutorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IStepExecutor Create<T>(in T step) where T: IStep
        {
            var tipo = typeof(IStepExecutor<>).MakeGenericType(step.GetType());
            var executor = _serviceProvider.GetService(tipo);

            if (executor == null)
                throw new NotImplementedExecutorException(step);

            var metodo = executor.GetType().GetMethod("SetStep");
            metodo?.Invoke(executor, new object[] { step });

            IStepExecutor result = (IStepExecutor)executor;
            return result;
        }
    }
}