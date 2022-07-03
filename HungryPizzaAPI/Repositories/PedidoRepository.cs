using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly APIDbContext _context;

        public PedidoRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<int> CriarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido.Id;
        }

        public async Task<List<Pedido>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take)
        {
            return await _context.Pedidos
                                 .Where(x => x.ClienteId == clienteId)
                                 .OrderByDescending(x => x.Data)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
        }

    }
}
