using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class testeEntradaLote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaLote_Entrada_EntradaId",
                table: "EntradaLote");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaLote_Entrada_EntradaId",
                table: "EntradaLote",
                column: "EntradaId",
                principalTable: "Entrada",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaLote_Entrada_EntradaId",
                table: "EntradaLote");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaLote_Entrada_EntradaId",
                table: "EntradaLote",
                column: "EntradaId",
                principalTable: "Entrada",
                principalColumn: "EntradaId");
        }
    }
}
