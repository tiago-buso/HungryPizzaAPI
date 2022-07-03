using Flunt.Notifications;
using HungryPizzaAPI.Models.Dominios;

namespace HungryPizzaAPI.Services
{
    public interface ISaboresService 
    {
        Task<List<Sabor>> SelecionarSaboresPorIds(List<int> saboresIds);
    }
}