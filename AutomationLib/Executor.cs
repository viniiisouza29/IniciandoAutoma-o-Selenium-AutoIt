using AutomationLib.Business;
using AutomationLib.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutomationLib
{
    public class Executor : BackgroundService
    {
        private const int DEFAULT_SLEEP_TIME = 1000;

        private readonly IDataAccess _dataAccess;
        private readonly List<MaquinaProcessModel> _processos;
        private readonly ILogger<Executor> _logger;
        private readonly IBusinessProcessFactory _businesProcessFactory;
        private readonly IServiceProvider _serviceProvider;

        public Executor(IDataAccess dataAccess, ILogger<Executor> logger, IBusinessProcessFactory businessProcessFactory, IServiceProvider serviceProvider)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _processos = new List<MaquinaProcessModel>();
            _businesProcessFactory = businessProcessFactory?? throw new ArgumentNullException(nameof(businessProcessFactory));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            int intervalo = DEFAULT_SLEEP_TIME;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    ObterProcessos();
                    Caso caso = ObterCaso();

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        using (var processo = _businesProcessFactory.ObterProcesso(caso, scope))
                        {
                            processo.Iniciar(caso);
                        }
                    }

                    intervalo = _dataAccess.ObterIntervalo();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                finally
                {
                    Thread.Sleep(intervalo);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            _logger.LogInformation("Finalizando o Executor de processos");
            GC.SuppressFinalize(this);
        }

        private void ObterProcessos()
        {
            _processos.Clear();
            _processos.AddRange(_dataAccess.ObterProcessosPrioridade(Environment.MachineName));

            if (_processos.Count == 0)
                _processos.Add(new MaquinaProcessModel { IdProcesso = _dataAccess.ObterProcessoGenerico(), Prioridade = 1 });
        }

        private Caso ObterCaso()
        {
            foreach(var processo in _processos)
            {
                if(processo.TipoProcesso == TipoProcesso.Servico)
                {
                    _logger.LogInformation($"Iniciando serviço. Processo:{processo.IdProcesso}");
                    return new Caso { IdProcesso = processo.IdProcesso };
                }

                _logger.LogInformation($"Buscando caso para o processo: {processo.IdProcesso}");
                var caso = _dataAccess.ObterProximoCaso(processo.IdProcesso, Environment.MachineName);

                if (caso is CasoInexistente)
                    _logger.LogInformation($"Nenhum caso encontrado para o processo: {processo.IdProcesso}");
                else
                {
                    _logger.LogInformation($"Caso {caso.IdCaso} encontrado para processamento.");
                    return caso;
                }
            }

            return new CasoInexistente();
        }
    }
}