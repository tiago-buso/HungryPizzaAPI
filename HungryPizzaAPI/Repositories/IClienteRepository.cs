namespace HungryPizzaAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<bool> ClienteExiste(int clienteId);
    }
}