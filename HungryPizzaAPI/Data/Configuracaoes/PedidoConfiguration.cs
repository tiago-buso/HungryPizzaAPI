using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.IdentificadorUnico).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.ValorTotal).HasColumnType("NUMERIC(4, 2)").IsRequired();


            builder.HasOne<Endereco>(p => p.Endereco)
           .WithMany(e => e.Pedidos)
           .HasForeignKey(p => p.EnderecoId);

            builder.HasOne<Cliente>(p => p.Cliente)
           .WithMany(e => e.Pedidos)
           .HasForeignKey(p => p.ClienteId);
        }
    }
}
