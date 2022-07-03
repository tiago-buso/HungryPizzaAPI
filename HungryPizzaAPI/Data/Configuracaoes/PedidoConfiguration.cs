using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class PedidoConfiguration : IEntityTypeConfiguration<PedidoPersistencia>
    {
        public void Configure(EntityTypeBuilder<PedidoPersistencia> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data).HasColumnType("datetime2").IsRequired();            
            builder.Property(p => p.ValorTotal).HasColumnType("NUMERIC(9, 2)").IsRequired();

            builder.HasOne<EnderecoPersistencia>(p => p.Endereco)
           .WithMany(e => e.Pedidos)
           .HasForeignKey(p => p.EnderecoId).IsRequired(false);

            builder.HasOne<ClientePersistencia>(p => p.Cliente)
           .WithMany(e => e.Pedidos)
           .HasForeignKey(p => p.ClienteId).IsRequired(false);
        }
    }
}
