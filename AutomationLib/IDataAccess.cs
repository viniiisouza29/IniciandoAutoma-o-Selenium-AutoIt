using AutomationLib.Model;

namespace AutomationLib
{
    public interface IDataAccess
    {
        int ObterIntervalo();
        IEnumerable<MaquinaProcessModel> ObterProcessosPrioridade(string machineName);
        int ObterProcessoGenerico();
        Caso ObterProximoCaso(int idProcesso, string machineName);
    }
}