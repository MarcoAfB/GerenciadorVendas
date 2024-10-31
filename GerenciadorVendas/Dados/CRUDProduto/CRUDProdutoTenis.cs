using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GerenciadorVendas.Modelos
{
    public class CRUDProdutoTenis
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDProdutoTenis(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarProdutoTenis(ProdutoTenis ProdutoTenis){
            _context.DBProdutoTenis.Add(ProdutoTenis);
            _context.SaveChanges();
        }

        public List<ProdutoTenis> ListarProdutoTenis(){
            var ProdutoTenis = _context.DBProdutoTenis;
            return ProdutoTenis.ToList();
        }
        public int QuantidadeProdutoTenissRegistrados(){
            var quantidadeProdutoTeniss = _context.DBProdutoTenis.Count();
            return quantidadeProdutoTeniss;
        }
        public ProdutoTenis BuscarProdutoTenisporID(int id){
            ProdutoTenis result = _context.DBProdutoTenis.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void AtualizarPrecoProdutoTenis(int id, double novoPreco){
            ProdutoTenis ProdutoTenis = _context.DBProdutoTenis.FirstOrDefault(x => x.Id == id);
            ProdutoTenis.AtualizarPreco(novoPreco);
            _context.SaveChanges();
        }

        public void DeletarProdutoTenis(int id){
            ProdutoTenis ProdutoTenis = _context.DBProdutoTenis.FirstOrDefault(x => x.Id == id);
            _context.DBProdutoTenis.Remove(_context.DBProdutoTenis.Single(c => c.Id == id));
            _context.SaveChangesAsync();
        
        }
    }
}