using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class CRUDCidade
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDCidade(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Cidade> SelecionarTodasCidades(){
            var Cidade = _context.DBCidade;
            return Cidade.ToList();
        }

        public List<Cidade> SelecionarTodasCidadesDeterminadoEstado(int IdEstado){
            var Cidade = _context.DBCidade.Where(e => e.EstadodaCidade.Id == IdEstado);
            return Cidade.ToList();
        }


    }
    
}