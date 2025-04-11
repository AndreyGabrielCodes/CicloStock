using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CicloStock.Migrations
{
    /// <inheritdoc />
    public partial class retiradaDefaultQuantidadeLocacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeProduto",
                table: "Locacao",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true,
                oldDefaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeProduto",
                table: "Locacao",
                type: "INT",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);
        }
    }
}
