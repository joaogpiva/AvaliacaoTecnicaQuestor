﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliacaoTecnicaQuestor.Api.Migrations
{
    public partial class AddUniqueToCodigoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bancos_Codigo",
                table: "Bancos",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bancos_Codigo",
                table: "Bancos");
        }
    }
}
