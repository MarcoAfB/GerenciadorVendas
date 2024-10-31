using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoPedido
    {

        private static CRUDProdutoTenis _crudProdutoTenis;
        private static CRUDProdutoRoupa _crudProdutoRoupa;
        private static CRUDPagamentoAPrazo _crudPagamentoAPrazo;
        private static CRUDPagamentoAVista _crudPagamentoAVista;
        private static CRUDPedido  _crudPedido;
        private InteracaoValidacao _interacaoValidacao = new();


        public InteracaoPedido(CRUDProdutoTenis crudProdutoTenis, CRUDProdutoRoupa crudProdutoRoupa, 
        CRUDPagamentoAPrazo crudPagamentoAPrazo, CRUDPagamentoAVista crudPagamentoAVista, CRUDPedido  crudPedido)
        {
            _crudProdutoTenis = crudProdutoTenis;
            _crudProdutoRoupa = crudProdutoRoupa;
            _crudPagamentoAPrazo = crudPagamentoAPrazo;
            _crudPagamentoAVista = crudPagamentoAVista;
            _crudPedido = crudPedido;
        }
        private InteracaoProdutoRoupa _interacaoProdutoRoupa = new(_crudProdutoRoupa);
        private InteracaoProdutoTenis _interacaoProdutoTenis = new(_crudProdutoTenis);
        private InteracaoPagamento _interacaoPagamento = new(_crudPagamentoAPrazo, _crudPagamentoAVista, _crudPedido);
        public void FazerPedido(Cliente cliente)
        {   
            string opcao = "0";
            Pedido pedido = new(cliente);
            do{
                Console.Clear();
                Console.WriteLine("1. Vender Tênis");
                Console.WriteLine("2. Vender Roupa");
                Console.WriteLine("0. Sair");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _interacaoProdutoTenis.ListarTodosProdutosTenis();
                        ProdutoTenis tenis = _interacaoProdutoTenis.SelecionarProdutoTenis();
                        Console.WriteLine("Selecione a quantidade desse produto");
                        int qntProdutoTenis = _interacaoValidacao.ReceberValorNatural();
                        if(tenis.Estoque.Quantidade >= qntProdutoTenis)
                        {
                            ItemPedido itemTenis = new(tenis, qntProdutoTenis);
                            pedido.AdicionarItem(itemTenis);
                        }
                        else
                        {
                            Console.WriteLine("Quantidade do produto em estoque é menor que a quantia desejada");
                        }
                        break;
                    case "2":
                        _interacaoProdutoRoupa.ListarTodosProdutosRoupa();
                        ProdutoRoupa roupa = _interacaoProdutoRoupa.SelecionarProdutoRoupa();
                        Console.WriteLine("Selecione a quantidade desse produto");
                        int qntProdutoRoupa = _interacaoValidacao.ReceberValorNatural();
                        if(roupa.Estoque.Quantidade >= qntProdutoRoupa)
                        {
                            ItemPedido itemRoupa = new(roupa, qntProdutoRoupa);
                            pedido.AdicionarItem(itemRoupa);
                        }
                        else
                        {
                            Console.WriteLine("Quantidade do produto em estoque é menor que a quantia desejada");
                        }
                        break;
                }

            }while(opcao!="0");
            cliente.AdicionarPedido(pedido);
            _crudPedido.AdicionarPedido(pedido);
            _interacaoPagamento.RealizarPagamento(pedido);
        }


        public void ListarPedidosCliente(Cliente cliente)
        {
            List<Pedido> pedidos = _crudPedido.ListarPedidosCliente(cliente);
            if(pedidos.Count() == 0)
            {
                Console.WriteLine("Cliente ainda não realizou pedidos");
            }
            int posicao=0;
            foreach(Pedido pedido in pedidos)
            {
                Console.WriteLine($"Posicao do pedido: {posicao}");
                Console.WriteLine($"Situacao do pedido: {pedido.SituacaoPedido}");
                posicao++;
            }
            Console.ReadLine();
        }

        public Pedido SelecionarPedidoCliente(Cliente cliente)
        {
            List<Pedido> pedidos = _crudPedido.ListarPedidosCliente(cliente);
            Console.WriteLine("Selecione o Tênis: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < pedidos.Count() && posicaoSelecionada >= 0)
                {
                    return pedidos[posicaoSelecionada];
                }
                else
                {
                    Console.WriteLine("Tênis selecionado incorretamente:");
                }
            }
        }

        public Pedido SelecionarPedidoPendenteCliente(Cliente cliente)
        {
            List<Pedido> pedidos = _crudPedido.ListarPedidosCliente(cliente);
            if(pedidos.Count() == 0)
            {
                Console.WriteLine("Cliente não possui pedidos");
            }
            Console.WriteLine("Selecione o Tênis: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < pedidos.Count() && posicaoSelecionada >= 0)
                {
                    if(pedidos[posicaoSelecionada].SituacaoPedido == "Pendente")
                    {
                        return pedidos[posicaoSelecionada];
                    }
                    else
                    {
                        Console.WriteLine("Pedido deve ser pendente");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Pedido selecionado incorretamente:");
                }
            }
        }

        public void DeletarProdutoTenis(int id)
        {
            _crudProdutoTenis.DeletarProdutoTenis(id);
        }


    }
}