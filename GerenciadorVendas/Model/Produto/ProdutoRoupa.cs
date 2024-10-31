using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;
namespace GerenciadorVendas.Modelos
{
    public class ProdutoRoupa : Produto
    {
        public string Tamanho { get; private set;}
        public ProdutoRoupa(string nome, string descricao, double preco, string tamanho) 
        :base(nome, descricao, preco)
        {
            Tamanho = tamanho;
        }
        private ProdutoRoupa():base(){}
    }
}