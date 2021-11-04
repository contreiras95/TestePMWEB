using Domain.Entities;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contexts
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Quarto> Quarto { get; set; }

        public DbSet<Foto> Foto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(new HotelMap().Configure);

            modelBuilder.Entity<Quarto>(new QuartoMap().Configure);

            modelBuilder.Entity<Foto>(new FotoMap().Configure);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Server=MARCIO-NB\\SQLEXPRESS; Database=TestePMWeb; Trusted_Connection=true;";
            return strCon;
        }
    }
}
