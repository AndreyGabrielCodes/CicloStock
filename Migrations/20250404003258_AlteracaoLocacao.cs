using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoLocacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacao_Produto_ProdutoId",
                table: "Locacao");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Locacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacao_Produto_ProdutoId",
                table: "Locacao",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacao_Produto_ProdutoId",
                table: "Locacao");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Locacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacao_Produto_ProdutoId",
                table: "Locacao",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
