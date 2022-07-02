using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(5000)").IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Cliente>(c => c.EnderecoId);

        }
    }
}
