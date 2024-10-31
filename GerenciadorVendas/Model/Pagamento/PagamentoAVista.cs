using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class PagamentoAVista:Pagamento
    {
        public PagamentoAVista(Pedido pedido):base(pedido){

            DataPagamento = DateTime.Now;
        }
        private PagamentoAVista():base(){}
    }
}