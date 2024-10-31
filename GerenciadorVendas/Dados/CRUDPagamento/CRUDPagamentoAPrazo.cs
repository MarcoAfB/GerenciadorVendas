using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorVendas.Modelos
{
    public class CRUDPagamentoAPrazo
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDPagamentoAPrazo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarPagamentoAPrazo(PagamentoAPrazo pagamento){
            _context.DBPagamentoAPrazo.Add(pagamento);
            _context.SaveChanges();
        }



    }
}

