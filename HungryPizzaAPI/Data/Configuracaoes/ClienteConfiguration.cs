using HungryPizzaAPI.Models.Persistencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClientePersistencia>
    {
        public void Configure(EntityTypeBuilder<ClientePersistencia> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(5000)").IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<ClientePersistencia>(c => c.EnderecoId);

        }
    }
}
