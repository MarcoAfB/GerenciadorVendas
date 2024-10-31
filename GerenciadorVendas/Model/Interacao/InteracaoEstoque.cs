using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoEstoque
    {
        private static CRUDEstoque _crudEstoque;
        private InteracaoValidacao _interacaoValidacao = new();
        private static CRUDProdutoTenis _crudProdutoTenis;
        private static CRUDProdutoRoupa _crudProdutoRoupa;
        public InteracaoEstoque(CRUDEstoque crudEstoque, CRUDProdutoTenis crudProdutoTenis, CRUDProdutoRoupa crudProdutoRoupa)
        {
            _crudEstoque = crudEstoque;
            _crudProdutoTenis = crudProdutoTenis;
            _crudProdutoRoupa = crudProdutoRoupa;
        }
        private InteracaoProdutoRoupa _interacaoProdutoRoupa = new(_crudProdutoRoupa);
        private InteracaoProdutoTenis _interacaoProdutoTenis = new(_crudProdutoTenis);
       public void AlterarQuantidadeProduto()
        {   
            string opcao = "0";
            int quantiaComprada;
            do{
                Console.Clear();
                Console.WriteLine("1. Comprar Tênis");
                Console.WriteLine("2. Comprar Roupa");
                Console.WriteLine("0. Sair");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ProdutoTenis tenis = _interacaoProdutoTenis.SelecionarProdutoTenis();
                        Console.WriteLine("Quantia do produto comprado: ");
                        quantiaComprada = _interacaoValidacao.ReceberValorNatural();
                        AdicionarProdutoEstoque(tenis, quantiaComprada);
                        break;
                    case "2":
                        _interacaoProdutoRoupa.ListarTodosProdutosRoupa();
                        ProdutoRoupa roupa = _interacaoProdutoRoupa.SelecionarProdutoRoupa();
                        Console.WriteLine("Quantia do produto comprado: ");
                        quantiaComprada = _interacaoValidacao.ReceberValorNatural();
                        AdicionarProdutoEstoque(roupa, quantiaComprada);
                        break;
                }

            }while(opcao!="0");
        }

        public void AdicionarProdutoEstoque(Produto produto, int quantidade)
        {
            _crudEstoque.AtualizarEstoqueAumentar(produto.Estoque, quantidade);
        }      
        public void DiminuirProdutoEstoque(Produto produto, int quantidade)
        {
            _crudEstoque.AtualizarEstoqueDiminuir(produto.Estoque, quantidade);
        }        
    }
}