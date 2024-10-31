using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Estoque
    {
        private readonly ApplicationDbContext context;
        public int Id{get; private set;}
        public int Quantidade{get; private set;}

        public Estoque()
        {
            Quantidade = 0;
        }

        public void aumentarQuantidade(int quantidade)
        {
            Quantidade = Quantidade+quantidade;
        }
        public void diminuirQuantidade(int quantidade)
        {
            Quantidade = Quantidade-quantidade;
        }
        
    }
}