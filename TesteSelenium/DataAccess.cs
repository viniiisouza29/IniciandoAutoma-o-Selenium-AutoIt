// See https://aka.ms/new-console-template for more information

using AutomationLib;
using AutomationLib.Model;

namespace TesteSelenium
{
    public class DataAccess : IDataAccess
    {
        public int ObterIntervalo()
        {
            return 1000;
        }

        public int ObterProcessoGenerico()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaquinaProcessModel> ObterProcessosPrioridade(string machineName)
        {
            return new List<MaquinaProcessModel>
            {
                new MaquinaProcessModel
                {
                    IdProcesso = 2,
                    TipoProcesso = TipoProcesso.Automacao,
                    Prioridade = 1
                },
                new MaquinaProcessModel
                {
                    IdProcesso = 1,
                    TipoProcesso = TipoProcesso.Servico,
                    Prioridade = 1
                }
            };
        }

        public Caso ObterProximoCaso(int idProcesso, string machineName)
        {
            if (idProcesso == 2)
                return new Caso { IdProcesso = idProcesso, IdCaso = 1 };

            return new CasoInexistente();
        }
    }
}