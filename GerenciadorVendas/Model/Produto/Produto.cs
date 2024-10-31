using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Produto
    {
        public int Id {get; private set;}
        public string Nome{get; private set;}
        public string Descricao{get; private set;}
        public double Preco{get; private set;}
        public Estoque Estoque{get; private set;}

        public Produto(string nome, string descricao, double preco){
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = new Estoque();

        }

        public Produto(){}

        public void AtualizarPreco(double novoPreco){
            Preco = novoPreco;
        }

    }
}