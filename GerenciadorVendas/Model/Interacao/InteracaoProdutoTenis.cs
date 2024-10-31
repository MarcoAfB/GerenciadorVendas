using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoProdutoTenis
    {

        private CRUDProdutoTenis _crudProdutoTenis;
        private InteracaoValidacao _interacaoValidacao = new();

        public InteracaoProdutoTenis(CRUDProdutoTenis crudProdutoTenis)
        {
            _crudProdutoTenis = crudProdutoTenis;
        }


        public void ListarTodosProdutosTenis(){
            List<ProdutoTenis> produtosTenis = _crudProdutoTenis.ListarProdutoTenis();
            int posicao=0;
            foreach(ProdutoTenis tenis in produtosTenis){
                Console.WriteLine($"ID: {posicao} - Nome: {tenis.Nome} - Preço: {tenis.Preco}");
                posicao++;
            }
         //   Console.ReadLine();
        }

      public ProdutoTenis SelecionarProdutoTenis()
        {
        //    ListarNomeClientes();
            List<ProdutoTenis> produtosTenis = _crudProdutoTenis.ListarProdutoTenis();
            int quantidadeClientes = _crudProdutoTenis.QuantidadeProdutoTenissRegistrados();
            Console.WriteLine("Selecione o Tênis: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < quantidadeClientes && posicaoSelecionada >= 0)
                {
                    return produtosTenis[posicaoSelecionada];
                }
                else
                {
                    Console.WriteLine("Tênis selecionado incorretamente:");
                }
            }
        }
      double EntradaPreco()
        {
            Console.WriteLine("Insira o preço o do produto: ");
            double numeracaoProduto = _interacaoValidacao.EntradaNumeroDouble();
            return numeracaoProduto;
        }
      public void AtualizarTenis(ProdutoTenis tenis)
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
                        _crudProdutoTenis.AtualizarPrecoProdutoTenis(tenis.Id, novoPreco);
                        break;
                    }
                
            }while(opcao!=0);
        }
        public void DeletarProdutoTenis(ProdutoTenis tenis)
        {
            _crudProdutoTenis.DeletarProdutoTenis(tenis.Id);
        }
    }
}