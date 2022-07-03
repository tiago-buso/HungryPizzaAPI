using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;

namespace HungryPizzaAPI.Services
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take);
        Task<int> CriarPedido(DateTime data, List<Pizza> pizzas, int? enderecoId, int? clienteId);
    }
}