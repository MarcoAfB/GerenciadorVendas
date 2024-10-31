using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorVendas.Modelos
{
    public class CRUDPagamentoAVista
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDPagamentoAVista(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarPagamentoAVista(PagamentoAVista pagamento){
            _context.DBPagamentoAVista.Add(pagamento);
            _context.SaveChanges();
        }





    }
}

