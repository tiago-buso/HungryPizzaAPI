namespace HungryPizzaAPI.Repositories
{
    public interface IEnderecoRepository
    {
        Task<bool> EnderecoExiste(int enderecoId);
    }
}