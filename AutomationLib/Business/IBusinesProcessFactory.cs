using AutomationLib.Model;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationLib.Business
{
    public interface IBusinessProcessFactory
    {
        BusinessProcess ObterProcesso(Caso caso, IServiceScope scope);
    }
}