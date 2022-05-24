using AutomationLib;
using AutomationLib.Configuration;
using Business;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeleniumAutomation.Configuration;
using System.Reflection;

namespace TesteSelenium
{
    public class Program
    {
        [STAThread]
        public static async Task Main()
        {
            var host = CreateHostBuilder().Build();
            await host.RunAsync();

            /*var services = new ServiceCollection();
            Setup(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                ConfigureBusinessProcessFactory(serviceProvider);

                var executor = serviceProvider.GetRequiredService<Executor>();

                await executor.StartAsync(CancellationToken.None);

                Thread.Sleep(1000);

                await executor.StopAsync(CancellationToken.None);
            }
            */
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.Configure<HostOptions>(options => options.ShutdownTimeout = TimeSpan.FromMinutes(5));

                    services.AddHostedService<Executor>();
                    services.AddLogging(configure => configure.AddConsole());

                    services.AddSingleton<IDataAccess, DataAccess>();

                    services.AddBusinessProcesses(Assembly.Load("Business"), Assembly.Load("Automation"));
                    services.AddSeleniumAutomation(new SeleniumConfiguration
                    {
                        DefaultTimeOut = TimeSpan.FromSeconds(15),
                        DefaultDelayBetweenSteps = TimeSpan.FromSeconds(2),
                    });

                    services.AddBuisinessProcessFactory(new Dictionary<int, Type> {
                        {1, typeof(ServicoTesteBusiness)},
                        {2, typeof(GoogleSearchBusiness)},
                    });
                });
        }
    }
}