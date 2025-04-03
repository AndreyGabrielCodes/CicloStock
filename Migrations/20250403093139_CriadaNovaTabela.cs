using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class CriadaNovaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradaLoteItem",
                columns: table => new
                {
                    EntradaLoteItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntradaLoteId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaLoteItem", x => x.EntradaLoteItemId);
                    table.ForeignKey(
                        name: "FK_EntradaLoteItem_EntradaLote_EntradaLoteId",
                        column: x => x.EntradaLoteId,
                        principalTable: "EntradaLote",
                        principalColumn: "EntradaLoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaLoteItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaLoteItem_EntradaLoteId",
                table: "EntradaLoteItem",
                column: "EntradaLoteId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaLoteItem_ProdutoId",
                table: "EntradaLoteItem",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaLoteItem");
        }
    }
}
