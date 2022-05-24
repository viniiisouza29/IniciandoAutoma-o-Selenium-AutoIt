using AutomationLib.Model;
using Microsoft.Extensions.Logging;

namespace AutomationLib.Business
{
    public abstract class BusinessProcess : IDisposable
    {
        private bool _disposed = false;
        protected readonly ILogger<BusinessProcess> _logger;

        protected BusinessProcess(ILogger<BusinessProcess> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Iniciar(Caso caso)
        {
            var name = GetType().Name;

            _logger.LogInformation($"Processo {name} iniciado");

            Executar(caso);

            _logger.LogInformation($"Processo {name} finalizado");
        }

        public abstract void Executar(Caso caso);
        public abstract void ReleaseResources();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
                ReleaseResources();

            _disposed = true;
        }
    }
}