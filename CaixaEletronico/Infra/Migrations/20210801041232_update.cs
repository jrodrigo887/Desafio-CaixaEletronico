using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaEletronico.Infra.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Conta");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Conta",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Conta");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Conta",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Conta",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
