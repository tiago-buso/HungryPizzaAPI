using Flunt.Notifications;
using HungryPizzaAPI.Data.Configuracaoes;
using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<SaborPersistencia> Sabores { get; set; }
        public DbSet<PizzaPersistencia> Pizzas { get; set; }
        public DbSet<EnderecoPersistencia> Enderecos { get; set; }
        public DbSet<ClientePersistencia> Clientes { get; set; }
        public DbSet<PedidoPersistencia> Pedidos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                     
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIDbContext).Assembly);
        }

       
    }
}
