using AutoMapper;
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
    }
}
