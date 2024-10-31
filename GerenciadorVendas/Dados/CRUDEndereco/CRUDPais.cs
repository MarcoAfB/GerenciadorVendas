using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class CRUDPais
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDPais(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Pais> SelecionarTodosPaises(){
            var pais = _context.DBPais;
            return pais.ToList();
        }

    }
    
}