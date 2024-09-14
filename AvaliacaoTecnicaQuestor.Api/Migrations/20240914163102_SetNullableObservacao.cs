using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliacaoTecnicaQuestor.Api.Migrations
{
    public partial class SetNullableObservacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Boletos",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Boletos",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
