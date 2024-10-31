using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoProduto
    {

        private static CRUDProdutoTenis _crudProdutoTenis;
        private static CRUDProdutoRoupa _crudProdutoRoupa;
        private InteracaoValidacao _interacaoValidacao = new();

        public InteracaoProduto(CRUDProdutoTenis crudProdutoTenis, CRUDProdutoRoupa crudProdutoRoupa)
        {
            _crudProdutoTenis = crudProdutoTenis;
            _crudProdutoRoupa = crudProdutoRoupa;
        }
        private InteracaoProdutoRoupa _interacaoProdutoRoupa = new(_crudProdutoRoupa);
        private InteracaoProdutoTenis _interacaoProdutoTenis = new(_crudProdutoTenis);
        public void CadastrarProduto()
        {
            int opcao;
            do{
                Console.Clear();
                Console.WriteLine("=== Cadastro de Produto ===");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Tênis");
                Console.WriteLine("2. Roupa");
                Console.WriteLine("0. Cancelar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                switch (opcao)
                {
                    case 1:
                        string nomeTenis = EntradaNomeProduto();
                        string descricaoTenis = EntradaDescriacaoProduto();
                        double precoTenis = EntradaPreco();
                        string numeracaoTenis = EntradaNumeracaoProduto();
                        ProdutoTenis produtoTenis = new ProdutoTenis(nomeTenis, descricaoTenis, precoTenis, numeracaoTenis);
                        _crudProdutoTenis.AdicionarProdutoTenis(produtoTenis);
                    break;
                    case 2:
                        string nomeRoupa = EntradaNomeProduto();
                        string descricaoRoupa = EntradaDescriacaoProduto();
                        double precoRoupa = EntradaPreco();
                        string numeracaoRoupa = EntradaNumeracaoProduto();
                        ProdutoRoupa produtoRoupa = new ProdutoRoupa(nomeRoupa, descricaoRoupa, precoRoupa, numeracaoRoupa);
                        _crudProdutoRoupa.AdicionarProdutoRoupa(produtoRoupa);
                    break;
                }
                
            }while(opcao!=0);

            Console.WriteLine("Produto cadastrado com sucesso!");
            Console.ReadLine();
        }
        string EntradaNomeProduto()
        {
            Validador validador = new();
            string nome;
            while(true){
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                try{
                    validador.ValidarStringNaoVazia(nome);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return nome;
        }
        string EntradaDescriacaoProduto()
        {
            Validador validador = new();
            string descricaoProduto;
            while(true){
                Console.Write("Descriação do produto: ");
                descricaoProduto = Console.ReadLine();
                try{
                    validador.ValidarStringNaoVazia(descricaoProduto);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return descricaoProduto;
        }
        double EntradaPreco()
        {
            Console.WriteLine("Insira o preço o do produto: ");
            double numeracaoProduto = _interacaoValidacao.EntradaNumeroDouble();
            return numeracaoProduto;
        }
        string EntradaNumeracaoProduto()
        {
            Console.WriteLine("Insira a numeração do produto: ");
            string numeracaoProduto = _interacaoValidacao.EntradaNumeroDouble().ToString();
            return numeracaoProduto;
        }

        public void ListarTodosProdutos(){
            int opcao;
            do{
                Console.Clear();
                Console.WriteLine("=== Listar produto ===");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Tênis");
                Console.WriteLine("2. Roupa");
                Console.WriteLine("0. Cancelar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                int posicao;
                switch (opcao)
                {
                    case 1:
                        List<ProdutoTenis> produtosTenis = _crudProdutoTenis.ListarProdutoTenis();
                        posicao=0;
                        foreach(ProdutoTenis tenis in produtosTenis){
                            Console.WriteLine($"ID: {posicao} - Nome: {tenis.Nome} - Preço: {tenis.Preco}");
                            posicao++;
                        }
                        Console.ReadLine();
                    break;
                    case 2:
                        List<ProdutoRoupa> produtosRoupa = _crudProdutoRoupa.ListarProdutoRoupa();
                        posicao=0;
                        foreach(ProdutoRoupa roupa in produtosRoupa){
                            Console.WriteLine($"ID: {posicao} - Nome: {roupa.Nome} - Preço: {roupa.Preco}");
                            posicao++;
                        }
                        Console.ReadLine();
                    break;
                }
            }while(opcao!=0);
        }
        public void ListarTodosProdutos1(){
            int opcao;
            do{
                Console.Clear();
                Console.WriteLine("=== Listar produto ===");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Tênis");
                Console.WriteLine("2. Roupa");
                Console.WriteLine("0. Cancelar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                int posicao;
                switch (opcao)
                {
                    case 1:
                        _interacaoProdutoTenis.ListarTodosProdutosTenis();
                    break;
                    case 2:
                        _interacaoProdutoRoupa.ListarTodosProdutosRoupa();
                    break;
                }
            }while(opcao!=0);
        }

        public void AtualizaProduto()
        {
           int opcao;
            do{
                Console.Clear();
                Console.WriteLine("=== Listar produto ===");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Tênis");
                Console.WriteLine("2. Roupa");
                Console.WriteLine("0. Cancelar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                int posicao;
                int quantidadeClientes;
                int idProduto;
                switch (opcao)
                {
                    case 1:
                        ProdutoTenis tenis = _interacaoProdutoTenis.SelecionarProdutoTenis();
                        _interacaoProdutoTenis.AtualizarTenis(tenis);
                    break;
                    case 2:
                        ProdutoRoupa roupa = _interacaoProdutoRoupa.SelecionarProdutoRoupa();
                        _interacaoProdutoRoupa.AtualizarRoupa(roupa); 
                    break;
                }
            }while(opcao!=0); 
        }


        public void DeletarProduto()
        {
           int opcao;
            do{
                Console.Clear();
                Console.WriteLine("=== Deletar Produto ===");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Tênis");
                Console.WriteLine("2. Roupa");
                Console.WriteLine("0. Cancelar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                int posicao;
                int quantidadeClientes;
                int idProduto;
                switch (opcao)
                {
                    case 1:
                        ProdutoTenis tenis = _interacaoProdutoTenis.SelecionarProdutoTenis();
                        _interacaoProdutoTenis.DeletarProdutoTenis(tenis);
                    break;
                    case 2:
                        ProdutoRoupa roupa = _interacaoProdutoRoupa.SelecionarProdutoRoupa();
                        _interacaoProdutoRoupa.DeletarProdutoRoupa(roupa); 
                    break;
                }
            }while(opcao!=0); 
        }
    }
}