using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class PizzaConfiguration : IEntityTypeConfiguration<PizzaPersistencia>
    {
        public void Configure(EntityTypeBuilder<PizzaPersistencia> builder)
        {
            builder.ToTable("Pizzas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PrecoTotal).HasColumnType("NUMERIC(9, 2)").IsRequired();

            builder.HasMany(left => left.Sabores)
            .WithMany(right => right.Pizzas)
            .UsingEntity(join => join.ToTable("PizzasSabores"));

            builder.HasOne<PedidoPersistencia>(pi => pi.Pedido)
           .WithMany(pe => pe.Pizzas)
           .HasForeignKey(pi => pi.PedidoId).IsRequired(false);
        }
    }
}
