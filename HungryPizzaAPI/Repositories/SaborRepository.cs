using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Repositories
{
    public class SaborRepository : ISaborRepository
    {
        private readonly APIDbContext _context;

        public SaborRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaborPersistencia>> SelecionarSaboresPorIds(List<int> saboresIds)
        {
            var sabores =  await _context.Sabores.AsNoTracking().Where(x => saboresIds.Contains(x.Id)).ToListAsync();
            //if (sabores != null)
            //{
            //    _context.Entry(sabores).State = EntityState.Detached;
            //}
            return sabores;
        }
    }
}
