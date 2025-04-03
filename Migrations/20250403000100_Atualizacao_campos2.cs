using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao_campos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoBarras",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Inconsistencia",
                table: "EntradaLote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoBarras",
                table: "Produto",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "Inconsistencia",
                table: "EntradaLote",
                type: "INTEGER",
                nullable: true);
        }
    }
}
