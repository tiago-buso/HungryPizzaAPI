using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Repositories
{
    public interface IPedidoRepository
    {
        Task<int> CriarPedido(PedidoPersistencia pedido);
        Task<List<PedidoPersistencia>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take);
    }
}