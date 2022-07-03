using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;
using HungryPizzaAPI.Models.Persistencias;
using HungryPizzaAPI.Repositories;

namespace HungryPizzaAPI.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<PedidoDTO>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take)
        {
            List<PedidoPersistencia> pedidos = await _pedidoRepository.SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(clienteId: clienteId, skip: skip, take: take);

            if (pedidos != null)
            {
                return _mapper.Map<List<PedidoDTO>>(pedidos);
            }

            return null;
        }

        public async Task<int> CriarPedido(DateTime data, List<Pizza> pizzas, int? enderecoId, int? clienteId)
        {
            int pedidoId = 0;

            Pedido pedido = MontarPedido(data: data, pizzas: pizzas, enderecoId: enderecoId, clienteId: clienteId);

            if (pedido != null)
            {
                PedidoPersistencia pedidoPersistencia = _mapper.Map<PedidoPersistencia>(pedido);
                pedidoId = await _pedidoRepository.CriarPedido(pedidoPersistencia); 
            }

            return pedidoId;
        }

        private Pedido MontarPedido(DateTime data, List<Pizza> pizzas, int? enderecoId, int? clienteId)
        {
            Pedido pedido = new Pedido(data: data, pizzas: pizzas, enderecoId: enderecoId, clienteId: clienteId);

            if (!pedido.IsValid)
            {
                throw new Exception(String.Join(", ", pedido.Notifications.ToList().Select(x => x.Message).ToArray()));
            }
            else
            {
                return pedido;
            }
        }
    }
}
