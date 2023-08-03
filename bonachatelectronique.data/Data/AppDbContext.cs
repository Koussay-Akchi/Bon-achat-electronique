using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using bonachatelecronique.data.Models;
using Microsoft.Extensions.Options;

namespace bonachatelecronique.data.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection"));
           
                // Replace _connectionString with your PostgreSQL connection string
                string connectionString = "Your_PostgreSQL_Connection_String";

        }
        //modelBuilder.HasDefaultSchema("bon_achat");

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BonAchatElectronique> BonAchatElectronique { get; set; }
        public DbSet<EtatBon> EtatBon { get; set; }
        public DbSet<TypeBon> TypeBon { get; set; }
        public DbSet<SourceBon> SourceBon { get; set; }


    }
}