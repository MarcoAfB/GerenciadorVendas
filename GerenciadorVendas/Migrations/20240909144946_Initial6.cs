using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBPagamento");

            migrationBuilder.DropColumn(
                name: "SituacaoPagamento",
                table: "PagamentosAVista");

            migrationBuilder.DropColumn(
                name: "SituacaoPagamento",
                table: "PagamentosAPrazo");

            migrationBuilder.DropColumn(
                name: "Situacao",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoConcluido");

            migrationBuilder.DropTable(
                name: "PedidoPendente");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoPagamento",
                table: "PagamentosAVista",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoPagamento",
                table: "PagamentosAPrazo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "DBPedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DBPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PagamentoSequence]"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SituacaoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBPagamento_DBPedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "DBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBPagamento_PedidoId",
                table: "DBPagamento",
                column: "PedidoId");
        }
    }
}
