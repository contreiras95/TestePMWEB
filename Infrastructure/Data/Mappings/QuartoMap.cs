using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Mappings
{
    public class QuartoMap : IEntityTypeConfiguration<Quarto>
    {
        public void Configure(EntityTypeBuilder<Quarto> builder)
        {
            builder.ToTable("Quarto");

            builder.HasKey(prop => prop.ID);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(prop => prop.HotelID)
               .HasConversion(prop => Convert.ToInt32(prop), prop => prop)
               .IsRequired()
               .HasColumnName("HotelID")
               .HasColumnType("int");

            builder.Property(prop => prop.NumeroOcupantes)
              .HasConversion(prop => Convert.ToInt32(prop), prop => prop)
              .IsRequired()
              .HasColumnName("NumeroOcupantes")
              .HasColumnType("int");

            builder.Property(prop => prop.NumeroAdultos)
               .HasConversion(prop => Convert.ToInt32(prop), prop => prop)
               .IsRequired()
               .HasColumnName("NumeroAdultos")
               .HasColumnType("int");

            builder.Property(prop => prop.NumeroCriancas)
                .HasConversion(prop => Convert.ToInt32(prop), prop => prop)
                .IsRequired()
                .HasColumnName("NumeroCriancas")
                .HasColumnType("int");

            builder.Property(prop => prop.Preco)
               .HasConversion(prop => Convert.ToDecimal(prop), prop => prop)
               .IsRequired()
               .HasColumnName("Preco")
               .HasColumnType("decimal(18, 2)");
        }
    }
}
