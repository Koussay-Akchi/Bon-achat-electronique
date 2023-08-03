using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bonachatelectronique.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bon_achat");

            migrationBuilder.CreateTable(
                name: "bon_achat_electronique",
                schema: "bon_achat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUtilisateur = table.Column<int>(type: "integer", nullable: false),
                    SoldeCarteUtilisateurAvant = table.Column<long>(type: "bigint", nullable: false),
                    SoldeCarteUtilisateurApres = table.Column<long>(type: "bigint", nullable: false),
                    DateGeneration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CodeEtat = table.Column<int>(type: "integer", nullable: false),
                    CodeType = table.Column<int>(type: "integer", nullable: false),
                    ValeurInitiale = table.Column<long>(type: "bigint", nullable: false),
                    ValeurRestante = table.Column<long>(type: "bigint", nullable: false),
                    EmailBeneficiaire = table.Column<string>(type: "text", nullable: false),
                    TelephoneBeneficiaire = table.Column<int>(type: "integer", nullable: false),
                    CodeSource = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bon_achat_electronique", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "etat_bon",
                schema: "bon_achat",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LibelleParDefaut = table.Column<string>(type: "text", nullable: false),
                    Couleur = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etat_bon", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "source_bon",
                schema: "bon_achat",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_source_bon", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "type_bon",
                schema: "bon_achat",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_bon", x => x.Code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bon_achat_electronique",
                schema: "bon_achat");

            migrationBuilder.DropTable(
                name: "etat_bon",
                schema: "bon_achat");

            migrationBuilder.DropTable(
                name: "source_bon",
                schema: "bon_achat");

            migrationBuilder.DropTable(
                name: "type_bon",
                schema: "bon_achat");
        }
    }
}
