using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class ProdutoTenis : Produto
    {

        public string Numeracao{get; private set;}
        public ProdutoTenis(string nome, string descricao, double preco, string numeracao):base(nome, descricao, preco){
            Numeracao = numeracao;
        }
        private ProdutoTenis():base(){}
    }
}