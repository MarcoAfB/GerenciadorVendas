using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoConcluido");

            migrationBuilder.DropTable(
                name: "PedidoPendente");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoPedido",
                table: "DBPedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituacaoPedido",
                table: "DBPedido");

            migrationBuilder.CreateTable(
                name: "PedidoConcluido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoConcluido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoConcluido_DBPedido_Id",
                        column: x => x.Id,
                        principalTable: "DBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPendente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPendente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoPendente_DBPedido_Id",
                        column: x => x.Id,
                        principalTable: "DBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
