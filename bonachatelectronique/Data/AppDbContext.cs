using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using bonachatelectronique.Models;
using Microsoft.Extensions.Options;

namespace bonachatelectronique.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        /*
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string connectionString = "PostgreSQLConnection";

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=root;Database=bon_achat;";
            options.UseNpgsql(connectionString);

        }
        //modelBuilder.HasDefaultSchema("bon_achat");

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BonAchatElectronique> BonAchatElectronique { get; set; }
        public DbSet<EtatBon> EtatBon { get; set; }
        public DbSet<TypeBon> TypeBon { get; set; }
        public DbSet<SourceBon> SourceBon { get; set; }


    }
}