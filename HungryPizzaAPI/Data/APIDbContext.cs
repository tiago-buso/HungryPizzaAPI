using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIDbContext).Assembly);
        }

       
    }
}
