using HungryPizzaAPI.Models.DTOs;

namespace HungryPizzaAPI.Services
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take);
    }
}