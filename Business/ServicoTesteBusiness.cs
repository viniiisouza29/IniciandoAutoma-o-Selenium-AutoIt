using AutomationLib.Business;
using AutomationLib.Model;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class ServicoTesteBusiness : BusinessProcess
    {
        public ServicoTesteBusiness(ILogger<BusinessProcess> logger) : base(logger)
        {
        }

        public override void Executar(Caso caso)
        {
            Thread.Sleep(2000);
        }

        public override void ReleaseResources()
        {
        }
    }
}