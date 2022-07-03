using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly APIDbContext _context;

        public EnderecoRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EnderecoExiste(int enderecoId)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == enderecoId) != null;
        }
    }
}
