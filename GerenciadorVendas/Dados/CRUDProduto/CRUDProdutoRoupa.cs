using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GerenciadorVendas.Modelos
{
    public class CRUDProdutoRoupa
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDProdutoRoupa(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarProdutoRoupa(ProdutoRoupa ProdutoRoupa){
            _context.DBProdutoRoupa.Add(ProdutoRoupa);
            _context.SaveChanges();
        }

        public List<ProdutoRoupa> ListarProdutoRoupa(){
            var ProdutoRoupa = _context.DBProdutoRoupa;
            return ProdutoRoupa.ToList();
        }
        public int QuantidadeProdutoRoupasRegistrados(){
            var quantidadeProdutoRoupas = _context.DBProdutoRoupa.Count();
            return quantidadeProdutoRoupas;
        }
        public ProdutoRoupa BuscarProdutoRoupaporID(int id){
            ProdutoRoupa result = _context.DBProdutoRoupa.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void AtualizarPrecoProdutoRoupa(int id, double novoPreco){
            ProdutoRoupa ProdutoRoupa = _context.DBProdutoRoupa.FirstOrDefault(x => x.Id == id);
            ProdutoRoupa.AtualizarPreco(novoPreco);
            _context.SaveChanges();
        }

        public void DeletarProdutoRoupa(int id){
            ProdutoRoupa ProdutoRoupa = _context.DBProdutoRoupa.FirstOrDefault(x => x.Id == id);
            _context.DBProdutoRoupa.Remove(_context.DBProdutoRoupa.Single(c => c.Id == id));
            _context.SaveChangesAsync();
        
        }
    }
}