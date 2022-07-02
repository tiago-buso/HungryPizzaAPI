﻿using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaAPI.Data.Configuracaoes
{
    public class SaborConfiguration : IEntityTypeConfiguration<Sabor>
    {
        public void Configure(EntityTypeBuilder<Sabor> builder)
        {
            builder.ToTable("Sabores");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("NUMERIC(4, 2)").IsRequired();
            builder.Property(p => p.EmFalta).HasColumnType("BIT").IsRequired().HasDefaultValue(false);
        }
    }   
}
