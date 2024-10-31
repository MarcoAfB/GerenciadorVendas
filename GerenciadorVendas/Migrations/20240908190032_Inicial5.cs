using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBCidade_CidadeId",
                table: "DBEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBEstado_EstadoId",
                table: "DBEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBPais_PaisId",
                table: "DBEndereco");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "DBEndereco",
                newName: "PaisEnderecoId");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "DBEndereco",
                newName: "EstadoEnderecoId");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "DBEndereco",
                newName: "CidadeEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_PaisId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_PaisEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_EstadoId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_EstadoEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_CidadeId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_CidadeEnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBCidade_CidadeEnderecoId",
                table: "DBEndereco",
                column: "CidadeEnderecoId",
                principalTable: "DBCidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBEstado_EstadoEnderecoId",
                table: "DBEndereco",
                column: "EstadoEnderecoId",
                principalTable: "DBEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBPais_PaisEnderecoId",
                table: "DBEndereco",
                column: "PaisEnderecoId",
                principalTable: "DBPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBCidade_CidadeEnderecoId",
                table: "DBEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBEstado_EstadoEnderecoId",
                table: "DBEndereco");

            migrationBuilder.DropForeignKey(
                name: "FK_DBEndereco_DBPais_PaisEnderecoId",
                table: "DBEndereco");

            migrationBuilder.RenameColumn(
                name: "PaisEnderecoId",
                table: "DBEndereco",
                newName: "PaisId");

            migrationBuilder.RenameColumn(
                name: "EstadoEnderecoId",
                table: "DBEndereco",
                newName: "EstadoId");

            migrationBuilder.RenameColumn(
                name: "CidadeEnderecoId",
                table: "DBEndereco",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_PaisEnderecoId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_EstadoEnderecoId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_DBEndereco_CidadeEnderecoId",
                table: "DBEndereco",
                newName: "IX_DBEndereco_CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBCidade_CidadeId",
                table: "DBEndereco",
                column: "CidadeId",
                principalTable: "DBCidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBEstado_EstadoId",
                table: "DBEndereco",
                column: "EstadoId",
                principalTable: "DBEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DBEndereco_DBPais_PaisId",
                table: "DBEndereco",
                column: "PaisId",
                principalTable: "DBPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
