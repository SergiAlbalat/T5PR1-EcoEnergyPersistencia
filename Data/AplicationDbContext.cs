using EcoEnergyRazorProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EcoEnergyRazorProject.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Simulacio> Simulacions { get; set; }
        public DbSet<ConsumAigua> ConsumsAigua {  get; set; }
        public DbSet<IndicadorEnergetic> IndicadorsEnergetics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connection = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
