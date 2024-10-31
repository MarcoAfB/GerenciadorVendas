using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class ItemPedido
    {
        public int Id {get; private set;}
        public Produto Produto{get; private set;}
        public int Quantidade{get; private set;}
        public double PrecoUnitario{get; private set;}
        public double PrecoFinal{get; private set;}

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;  
            PrecoUnitario = produto.Preco;
            PrecoFinal = PrecoUnitario*Quantidade;
        }

        private ItemPedido(){}
    }
}