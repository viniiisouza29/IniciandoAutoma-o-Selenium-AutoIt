using Automation.PesquisaGoogle;
using AutomationLib.Business;
using AutomationLib.Model;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class GoogleSearchBusiness : BusinessProcess
    {
        private readonly PesquisaGoogleAutomation _automation;
        private readonly PesquisaGoogleAutomation _automation1;

        public GoogleSearchBusiness(ILogger<BusinessProcess> logger, PesquisaGoogleAutomation automation, PesquisaGoogleAutomation automation1) : base(logger)
        {
            _automation = automation ?? throw new ArgumentNullException(nameof(automation));
            _automation1 = automation1 ?? throw new ArgumentNullException(nameof(automation1));
        }

        public override void Executar(Caso caso)
        {
            _automation1.Pesquisar("Rhitmo");
            _automation.Pesquisar("Grupo elo");

            var links = _automation.ObterLinks();
            foreach (var link in links)
            {
                Console.WriteLine($"Nome: {link.Nome}, Link: {link.Link}");
            }
        }

        public override void ReleaseResources()
        {
            _automation?.Dispose();
            _automation1?.Dispose();
        }
    }
}
