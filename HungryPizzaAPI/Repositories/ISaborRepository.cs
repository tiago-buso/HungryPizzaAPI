using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Repositories
{
    public interface ISaborRepository
    {
        Task<List<SaborPersistencia>> SelecionarSaboresPorIds(List<int> saboresIds);
    }
}