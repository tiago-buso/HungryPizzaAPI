using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Rua).HasColumnType("VARCHAR(5000)").IsRequired();
            builder.Property(p => p.CEP).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("VARCHAR(1000)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("VARCHAR(2)").IsRequired();
        }
    }
}
