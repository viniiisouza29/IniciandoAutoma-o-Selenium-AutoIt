using AutomationLib.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutomationLib.Business
{
    public class BusinessProcessFactory : IBusinessProcessFactory
    {
        private readonly Dictionary<int, Type> _tiposProcesso;
        private readonly ILogger<BusinessProcessFactory> _logger;
        private readonly ILogger<BusinessProcess> _loggerProcess;

        public BusinessProcessFactory(ILogger<BusinessProcessFactory> logger, ILogger<BusinessProcess> loggerProcess, BusinesProcessFactoryConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _loggerProcess = loggerProcess ?? throw new ArgumentNullException(nameof(loggerProcess));
            _tiposProcesso = configuration.ProcessTypes;
        }

        public BusinessProcess ObterProcesso(Caso caso, IServiceScope scope)
        {
            if (!_tiposProcesso.ContainsKey(caso.IdProcesso))
            {
                _logger.LogWarning($"BusinessProcess para IdProcesso = {caso.IdProcesso} não encontrado");
                return new BusinessProcessInexistente(_loggerProcess);
            }

            Type tipo = _tiposProcesso[caso.IdProcesso];
            var processo = scope.ServiceProvider.GetService(tipo) as BusinessProcess;
            return processo ?? new BusinessProcessInexistente(_loggerProcess);
        }
    }
}