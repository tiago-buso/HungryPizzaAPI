using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class PizzaSaborConfiguration : IEntityTypeConfiguration<PizzaSabor>
    {
        public void Configure(EntityTypeBuilder<PizzaSabor> builder)
        {
            builder.ToTable("PizzaSabores");
            builder.HasKey(ps => new { ps.PizzaId, ps.SaborId });

            builder.HasOne<Pizza>(ps => ps.Pizza)
                   .WithMany(p => p.PizzaSabores)
                   .HasForeignKey(ps => ps.PizzaId);

            builder.HasOne<Sabor>(ps => ps.Sabor)
                   .WithMany(p => p.PizzaSabores)
                   .HasForeignKey(ps => ps.SaborId);

        }
    }
}
