using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Pedido
    {
        public int Id {get; private set;}
        public Cliente Cliente{get; private set;}
        public DateTime Data{get; private set;}
        public List<ItemPedido> Items{get; private set;} = [];
        public string SituacaoPedido{get; private set;}

        public Pedido(Cliente cliente)
        {
            Cliente = cliente;
            Data = DateTime.Now;
            SituacaoPedido = "Pendente";
        }      
        public Pedido(){}  

        public void AdicionarItem(ItemPedido item)
        {
            Items.Add(item);
        }

        public void calcularValorTotal()
        {
            double valorTotal=0;
            foreach(ItemPedido item in Items)
            {
                valorTotal = valorTotal + item.PrecoFinal;
            }
            Console.WriteLine(valorTotal);
        }

        public void PediodoConcluido()
        {
            SituacaoPedido = "Concluido";
        }

    }
}