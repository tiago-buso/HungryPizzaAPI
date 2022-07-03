using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly APIDbContext _context;

        public ClienteRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ClienteExiste(int clienteId)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId) != null;
        }

    }
}
