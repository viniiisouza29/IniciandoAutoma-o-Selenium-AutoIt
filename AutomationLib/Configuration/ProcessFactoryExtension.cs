using AutomationLib.Automation;
using AutomationLib.Business;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutomationLib.Configuration
{
    public static class ProcessFactoryExtension
    {
        public static void AddBusinessProcesses(this IServiceCollection services, params Assembly[] businessAssembly)
        {
            var targetTypes = new List<Type> { typeof(BusinessProcess), typeof(IAutomation) };

            if (businessAssembly == null || businessAssembly.Length == 0)
                businessAssembly = AppDomain.CurrentDomain.GetAssemblies();

            var assembliesToConfigure = new List<Assembly>(businessAssembly)
            {
                Assembly.GetExecutingAssembly()
            };

            foreach (var assembly in assembliesToConfigure)
            {
                var tipos = assembly.GetTypes()
                    .Where(t => !t.IsAbstract && targetTypes.Any(target => t.IsAssignableTo(target)));

                foreach (var t in tipos)
                {
                    services.AddTransient(t);
                }
            }
        }

        public static IServiceCollection AddBuisinessProcessFactory(this IServiceCollection services, Dictionary<int, Type> processTypes)
        {
            var configuration = new BusinesProcessFactoryConfiguration
            {
                ProcessTypes = processTypes
            };

            services.AddSingleton(configuration);
            services.AddSingleton<IBusinessProcessFactory, BusinessProcessFactory>();

            return services;
        }
    }
}