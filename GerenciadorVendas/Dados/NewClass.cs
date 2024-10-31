using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorVendas.Modelos;
public class ApplicationDbContext : DbContext
{
    public DbSet<Estoque> DBEstoque { get; set; }
    public DbSet<Cidade> DBCidade { get; set; }
    public DbSet<Estado> DBEstado { get; set; }
    public DbSet<Pais> DBPais { get; set; }
    public DbSet<Cliente> DBCliente { get; set; }
    public DbSet<Endereco> DBEndereco { get; set; }
    public DbSet<ItemPedido> DBItemPedido { get; set; }
    public DbSet<Pagamento> DBPagamento { get; set; }
    public DbSet<PagamentoAPrazo> DBPagamentoAPrazo { get; set; }
    public DbSet<PagamentoAVista> DBPagamentoAVista { get; set; }
    public DbSet<Parcela> DBParcela { get; set; }
    public DbSet<Pedido> DBPedido { get; set; }
    public DbSet<ProdutoRoupa> DBProdutoRoupa { get; set; }
    public DbSet<ProdutoTenis> DBProdutoTenis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-4NL5VP4\\SQLEXPRESS;Database=GerenciadorVendas;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=True;TrustServerCertificate=True;");
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{


modelBuilder.Entity<Endereco>()
    .HasOne(e => e.PaisEndereco)
    .WithMany()
    .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<Endereco>()
    .HasOne(e => e.EstadoEndereco)
    .WithMany()
    .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<Endereco>()
    .HasOne(e => e.CidadeEndereco)
    .WithMany()
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Pagamento>()
        .UseTpcMappingStrategy();

    modelBuilder.Entity<PagamentoAVista>()
        .ToTable("PagamentosAVista");

    modelBuilder.Entity<PagamentoAPrazo>()
        .ToTable("PagamentosAPrazo");

    modelBuilder.Entity<Produto>()
        .UseTpcMappingStrategy();

    modelBuilder.Entity<ProdutoRoupa>()
        .ToTable("ProdutoRoupa");

    modelBuilder.Entity<ProdutoTenis>()
        .ToTable("ProdutoTenis");


}


}