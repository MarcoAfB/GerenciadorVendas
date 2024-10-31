using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class CRUDEstoque
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDEstoque(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AtualizarEstoqueAumentar(Estoque estoque, int quantia){
            Estoque estoque1 = _context.DBEstoque.FirstOrDefault(x => x.Id == estoque.Id);
            estoque1.aumentarQuantidade(quantia);
            _context.SaveChanges();
        }
        public void AtualizarEstoqueDiminuir(Estoque estoque, int quantia){
            Estoque estoque1 = _context.DBEstoque.FirstOrDefault(x => x.Id == estoque.Id);
            estoque1.diminuirQuantidade(quantia);
            _context.SaveChanges();
        }

    }
    
}