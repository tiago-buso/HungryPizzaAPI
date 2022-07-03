using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models.Persistencias;
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

        public async Task<int> CriarPedido(PedidoPersistencia pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            _context.Pedidos.Add(pedido);

            foreach (var pizza in pedido.Pizzas)
            {
                foreach(var sabor in pizza.Sabores)
                {
                    _context.Entry(sabor).State = EntityState.Unchanged;
                }
            }
            
            await _context.SaveChangesAsync();

            return pedido.Id;
        }

        public async Task<List<PedidoPersistencia>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take)
        {
            return await _context.Pedidos.Include(pe => pe.Pizzas)
                                 .Where(x => x.ClienteId == clienteId)
                                 .OrderByDescending(x => x.Data)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
        }

    }
}
