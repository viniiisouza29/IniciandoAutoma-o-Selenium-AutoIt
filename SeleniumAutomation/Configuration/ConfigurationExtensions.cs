using AutomationLib.Automation;
using Microsoft.Extensions.DependencyInjection;
using SeleniumAutomation.StepExecutor;
using System.Reflection;

namespace SeleniumAutomation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddSeleniumAutomation(this IServiceCollection services, SeleniumConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<StepExecutorFactory, StepExecutorFactory>();
            services.AddScoped<IWebAutomation, SeleniumWebAutomation>();
            services.AddStepExecutors();

            return services;
        }

        private static IServiceCollection AddStepExecutors(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var tipos = assembly.GetTypes()
                .Where(t => 
                    !t.IsAbstract && 
                    t.IsClass && 
                    t.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IStepExecutor<>)));

            foreach (var t in tipos)
            {
                var ifaceTypes = t
                    .GetTypeInfo()
                    .ImplementedInterfaces
                    .Where(i => i.Name == typeof(IStepExecutor<>).Name);

                foreach (var ifaceType in ifaceTypes)
                {
                    services.AddTransient(ifaceType, t);
                }
            }

            return services;
        }
    }
}