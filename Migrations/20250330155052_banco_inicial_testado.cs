using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class banco_inicial_testado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Situacao = table.Column<int>(type: "INT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataFim = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.EntradaId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Situacao = table.Column<int>(type: "INT", nullable: false),
                    CodigoBarras = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "EntradaLote",
                columns: table => new
                {
                    EntradaLoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Situacao = table.Column<int>(type: "INT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataFim = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Inconsistencia = table.Column<short>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaLote", x => x.EntradaLoteId);
                    table.ForeignKey(
                        name: "FK_EntradaLote_Entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
                        principalColumn: "EntradaId");
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    LocacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Situacao = table.Column<int>(type: "INT", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "INT", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.LocacaoId);
                    table.ForeignKey(
                        name: "FK_Locacao_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaLote_EntradaId",
                table: "EntradaLote",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ProdutoId",
                table: "Locacao",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaLote");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
