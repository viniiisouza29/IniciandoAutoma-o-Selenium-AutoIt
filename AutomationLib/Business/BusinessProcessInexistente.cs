using AutomationLib.Model;
using Microsoft.Extensions.Logging;

namespace AutomationLib.Business
{
    public class BusinessProcessInexistente : BusinessProcess
    {
        public BusinessProcessInexistente(ILogger<BusinessProcess> logger) : base(logger)
        {
        }

        public override void Executar(Caso caso)
        {
        }

        public override void ReleaseResources()
        {
        }
    }
}