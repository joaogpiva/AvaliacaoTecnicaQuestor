using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AvaliacaoTecnicaQuestor.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    PercentualJuros = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomePagador = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdentificacaoPagador = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    NomeBeneficiario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdentificacaoBeneficiario = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observacao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    BancoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletos_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_BancoId",
                table: "Boletos",
                column: "BancoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
