﻿// <auto-generated />
using System;
using GerenciadorVendas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("PagamentoSequence");

            modelBuilder.HasSequence("ProdutoSequence");

            modelBuilder.Entity("GerenciadorVendas.Modelos.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadodaCidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadodaCidadeId");

                    b.ToTable("DBCidade");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("DBCliente");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CidadeEnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoEnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisEnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeEnderecoId");

                    b.HasIndex("EstadoEnderecoId");

                    b.HasIndex("PaisEnderecoId");

                    b.ToTable("DBEndereco");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisdoEstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaisdoEstadoId");

                    b.ToTable("DBEstado");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DBEstoque");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoFinal")
                        .HasColumnType("float");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("float");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("DBItemPedido");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [PagamentoSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DBPais");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("PagamentoPertencenteId")
                        .HasColumnType("int");

                    b.Property<string>("SituacaoParcela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorPrcela")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoPertencenteId");

                    b.ToTable("DBParcela");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("SituacaoPedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("DBPedido");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [ProdutoSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Produto");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.PagamentoAPrazo", b =>
                {
                    b.HasBaseType("GerenciadorVendas.Modelos.Pagamento");

                    b.Property<int>("Prazo")
                        .HasColumnType("int");

                    b.Property<double>("ValorCadaParcela")
                        .HasColumnType("float");

                    b.ToTable("PagamentosAPrazo", (string)null);
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.PagamentoAVista", b =>
                {
                    b.HasBaseType("GerenciadorVendas.Modelos.Pagamento");

                    b.ToTable("PagamentosAVista", (string)null);
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.ProdutoRoupa", b =>
                {
                    b.HasBaseType("GerenciadorVendas.Modelos.Produto");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProdutoRoupa", (string)null);
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.ProdutoTenis", b =>
                {
                    b.HasBaseType("GerenciadorVendas.Modelos.Produto");

                    b.Property<string>("Numeracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProdutoTenis", (string)null);
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Cidade", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Estado", "EstadodaCidade")
                        .WithMany("CidadesdoEstado")
                        .HasForeignKey("EstadodaCidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadodaCidade");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Cliente", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Endereco", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Cidade", "CidadeEndereco")
                        .WithMany()
                        .HasForeignKey("CidadeEnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciadorVendas.Modelos.Estado", "EstadoEndereco")
                        .WithMany()
                        .HasForeignKey("EstadoEnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciadorVendas.Modelos.Pais", "PaisEndereco")
                        .WithMany()
                        .HasForeignKey("PaisEnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CidadeEndereco");

                    b.Navigation("EstadoEndereco");

                    b.Navigation("PaisEndereco");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Estado", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Pais", "PaisdoEstado")
                        .WithMany()
                        .HasForeignKey("PaisdoEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaisdoEstado");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.ItemPedido", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Pedido", null)
                        .WithMany("Items")
                        .HasForeignKey("PedidoId");

                    b.HasOne("GerenciadorVendas.Modelos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pagamento", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Parcela", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.PagamentoAPrazo", "PagamentoPertencente")
                        .WithMany("Parcelas")
                        .HasForeignKey("PagamentoPertencenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PagamentoPertencente");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pedido", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Produto", b =>
                {
                    b.HasOne("GerenciadorVendas.Modelos.Estoque", "Estoque")
                        .WithMany()
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Estado", b =>
                {
                    b.Navigation("CidadesdoEstado");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.Pedido", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("GerenciadorVendas.Modelos.PagamentoAPrazo", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
