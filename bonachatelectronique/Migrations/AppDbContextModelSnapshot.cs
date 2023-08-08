using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bonachatelectronique.Data;

#nullable disable

namespace bonachatelectronique.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bonachatelectronique.Models.BonAchatElectronique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CodeEtat")
                        .HasColumnType("integer");

                    b.Property<int>("CodeSource")
                        .HasColumnType("integer");

                    b.Property<int>("CodeType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateGeneration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailBeneficiaire")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUtilisateur")
                        .HasColumnType("integer");

                    b.Property<long>("SoldeCarteUtilisateurApres")
                        .HasColumnType("bigint");

                    b.Property<long>("SoldeCarteUtilisateurAvant")
                        .HasColumnType("bigint");

                    b.Property<int>("TelephoneBeneficiaire")
                        .HasColumnType("integer");

                    b.Property<long>("ValeurInitiale")
                        .HasColumnType("bigint");

                    b.Property<long>("ValeurRestante")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("bon_achat_electronique", "bon_achat");
                });

            modelBuilder.Entity("bonachatelectronique.Models.EtatBon", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Code"));

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LibelleParDefaut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("etat_bon", "bon_achat");
                });

            modelBuilder.Entity("bonachatelectronique.Models.SourceBon", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Code"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("source_bon", "bon_achat");
                });

            modelBuilder.Entity("bonachatelectronique.Models.TypeBon", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Code"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("type_bon", "bon_achat");
                });
#pragma warning restore 612, 618
        }
    }
}
