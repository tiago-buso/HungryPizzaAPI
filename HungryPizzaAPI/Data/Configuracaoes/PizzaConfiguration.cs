using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizzas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PrecoTotal).HasColumnType("NUMERIC(4, 2)").IsRequired();


            builder.HasOne<Pedido>(pi => pi.Pedido)
           .WithMany(pe => pe.Pizzas)
           .HasForeignKey(pi => pi.PedidoId);
        }
    }
}
