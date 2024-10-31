using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MinhasEntidades",
                table: "MinhasEntidades");

            migrationBuilder.RenameTable(
                name: "MinhasEntidades",
                newName: "DBEstoque");

            migrationBuilder.CreateSequence(
                name: "PagamentoSequence");

            migrationBuilder.CreateSequence(
                name: "ProdutoSequence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBEstoque",
                table: "DBEstoque",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DBPais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProdutoSequence]"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_DBEstoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "DBEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoRoupa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProdutoSequence]"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoRoupa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoRoupa_DBEstoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "DBEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoTenis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProdutoSequence]"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    Numeracao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoTenis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoTenis_DBEstoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "DBEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisdoEstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBEstado_DBPais_PaisdoEstadoId",
                        column: x => x.PaisdoEstadoId,
                        principalTable: "DBPais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBCidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadodaCidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBCidade_DBEstado_EstadodaCidadeId",
                        column: x => x.EstadodaCidadeId,
                        principalTable: "DBEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBEndereco_DBCidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "DBCidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBEndereco_DBEstado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "DBEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBEndereco_DBPais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "DBPais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBCliente_DBEndereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "DBEndereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBPedido_DBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "DBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "float", nullable: false),
                    PrecoFinal = table.Column<double>(type: "float", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBItemPedido_DBPedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "DBPedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DBPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PagamentoSequence]"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    SituacaoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PagamentosAPrazo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PagamentoSequence]"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    SituacaoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prazo = table.Column<int>(type: "int", nullable: false),
                    ValorCadaParcela = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosAPrazo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosAPrazo_DBPedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "DBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentosAVista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PagamentoSequence]"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    SituacaoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosAVista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosAVista_DBPedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "DBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBParcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPrcela = table.Column<double>(type: "float", nullable: false),
                    SituacaoParcela = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagamentoPertencenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBParcela_PagamentosAPrazo_PagamentoPertencenteId",
                        column: x => x.PagamentoPertencenteId,
                        principalTable: "PagamentosAPrazo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBCidade_EstadodaCidadeId",
                table: "DBCidade",
                column: "EstadodaCidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_DBCliente_EnderecoId",
                table: "DBCliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBEndereco_CidadeId",
                table: "DBEndereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_DBEndereco_EstadoId",
                table: "DBEndereco",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBEndereco_PaisId",
                table: "DBEndereco",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_DBEstado_PaisdoEstadoId",
                table: "DBEstado",
                column: "PaisdoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBItemPedido_PedidoId",
                table: "DBItemPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBItemPedido_ProdutoId",
                table: "DBItemPedido",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBPagamento_PedidoId",
                table: "DBPagamento",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBParcela_PagamentoPertencenteId",
                table: "DBParcela",
                column: "PagamentoPertencenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DBPedido_ClienteId",
                table: "DBPedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosAPrazo_PedidoId",
                table: "PagamentosAPrazo",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosAVista_PedidoId",
                table: "PagamentosAVista",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoRoupa_EstoqueId",
                table: "ProdutoRoupa",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoTenis_EstoqueId",
                table: "ProdutoTenis",
                column: "EstoqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBItemPedido");

            migrationBuilder.DropTable(
                name: "DBPagamento");

            migrationBuilder.DropTable(
                name: "DBParcela");

            migrationBuilder.DropTable(
                name: "PagamentosAVista");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "ProdutoRoupa");

            migrationBuilder.DropTable(
                name: "ProdutoTenis");

            migrationBuilder.DropTable(
                name: "PagamentosAPrazo");

            migrationBuilder.DropTable(
                name: "DBPedido");

            migrationBuilder.DropTable(
                name: "DBCliente");

            migrationBuilder.DropTable(
                name: "DBEndereco");

            migrationBuilder.DropTable(
                name: "DBCidade");

            migrationBuilder.DropTable(
                name: "DBEstado");

            migrationBuilder.DropTable(
                name: "DBPais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBEstoque",
                table: "DBEstoque");

            migrationBuilder.DropSequence(
                name: "PagamentoSequence");

            migrationBuilder.DropSequence(
                name: "ProdutoSequence");

            migrationBuilder.RenameTable(
                name: "DBEstoque",
                newName: "MinhasEntidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MinhasEntidades",
                table: "MinhasEntidades",
                column: "Id");
        }
    }
}
