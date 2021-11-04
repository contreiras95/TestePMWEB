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
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("Foto");

            builder.HasKey(prop => prop.ID);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(prop => prop.Arquivo)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Arquivo")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(prop => prop.Tipo)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Tipo")
                .HasColumnType("varchar(50)")
                .HasMaxLength(100);

            builder.Property(prop => prop.Codigo)
                .HasConversion(prop => Convert.ToInt32(prop), prop => prop)
                .IsRequired()
                .HasColumnName("Codigo")
                .HasColumnType("int");
        }
    }
}
