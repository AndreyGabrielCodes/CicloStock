using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class IncluidoCampoQuantidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "EntradaLoteItem",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "EntradaLoteItem");
        }
    }
}
