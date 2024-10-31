using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public abstract class Pagamento
    {
        public int Id {get; private set;}
        public Pedido Pedido{get; private set;}
        public double ValorTotal{get; private set;}
        public DateTime DataPagamento{get; protected set;}
        public Pagamento(Pedido pedido)
        {
            Pedido = pedido;
            calcularValorTotal();
        //    pedido.Situacao = "Finalizado";
        }
        public Pagamento(){}

        private void calcularValorTotal()
        {
            foreach(ItemPedido item in Pedido.Items)
            {
                ValorTotal = ValorTotal + item.PrecoFinal;
            }
        }
    }
}