using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoProdutoRoupa
    {

        private CRUDProdutoRoupa _crudProdutoRoupa;
        private InteracaoValidacao _interacaoValidacao = new();

        public InteracaoProdutoRoupa(CRUDProdutoRoupa crudProdutoRoupa)
        {
            _crudProdutoRoupa = crudProdutoRoupa;
        }


        public void ListarTodosProdutosRoupa(){
            List<ProdutoRoupa> produtosRoupa = _crudProdutoRoupa.ListarProdutoRoupa();
            int posicao=0;
            foreach(ProdutoRoupa roupa in produtosRoupa){
                Console.WriteLine($"ID: {posicao} - Nome: {roupa.Nome} - Preço: {roupa.Preco}");
                posicao++;
            }

        }

      public ProdutoRoupa SelecionarProdutoRoupa()
        {
        //    ListarNomeClientes();
            List<ProdutoRoupa> produtosRoupa = _crudProdutoRoupa.ListarProdutoRoupa();
            int quantidadeClientes = _crudProdutoRoupa.QuantidadeProdutoRoupasRegistrados();
            Console.WriteLine("Selecione a Roupa: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < quantidadeClientes && posicaoSelecionada >= 0)
                {
                    return produtosRoupa[posicaoSelecionada];
                }
                else
                {
                    Console.WriteLine("Roupa selecionado incorretamente:");
                }
            }
        }

     public void AtualizarRoupa(ProdutoRoupa roupa)
        {
            int opcao=0;
            do{

                Console.Clear();
                Console.WriteLine("Atualizar");
                Console.WriteLine("1. Preço");
                Console.WriteLine("0. Salvar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                
                switch(opcao){
                    case 1:
                        double novoPreco = EntradaPreco();
                        _crudProdutoRoupa.AtualizarPrecoProdutoRoupa(roupa.Id, novoPreco);
                        break;
                    }
                
            }while(opcao!=0);
        }

        public void DeletarProdutoRoupa(ProdutoRoupa roupa)
        {
            _crudProdutoRoupa.DeletarProdutoRoupa(roupa.Id);
        }
        double EntradaPreco()
        {
            Console.WriteLine("Insira o preço o do produto: ");
            double numeracaoProduto = _interacaoValidacao.EntradaNumeroDouble();
            return numeracaoProduto;
        }
    }
}