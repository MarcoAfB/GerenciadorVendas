using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class CRUDEstado
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDEstado(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Estado> SelecionarTodosEstados(){
            var Estado = _context.DBEstado;
            return Estado.ToList();
        }

        public List<Estado> SelecionarTodosEstadosDeterminadoPais(int IdPais){
            var Estado = _context.DBEstado.Where(e => e.PaisdoEstado.Id == IdPais);
            return Estado.ToList();
        }
    }
    
}