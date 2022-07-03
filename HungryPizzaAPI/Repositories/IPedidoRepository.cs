using HungryPizzaAPI.Models;

namespace HungryPizzaAPI.Repositories
{
    public interface IPedidoRepository
    {
        Task<int> CriarPedido(Pedido pedido);
        Task<List<Pedido>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take);
    }
}