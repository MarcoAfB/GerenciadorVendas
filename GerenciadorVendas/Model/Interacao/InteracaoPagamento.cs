using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoPagamento
    {
        private CRUDPagamentoAPrazo _crudPagamentoAPrazo;
        private CRUDPagamentoAVista _crudPagamentoAVista;
        private CRUDPedido _crudPedido;
        private InteracaoValidacao _interacaoValidacao = new();

        public InteracaoPagamento(CRUDPagamentoAPrazo crudPagamentoAPrazo, CRUDPagamentoAVista crudPagamentoAVista, CRUDPedido crudPedido)
        {
            _crudPagamentoAPrazo = crudPagamentoAPrazo;
            _crudPagamentoAVista = crudPagamentoAVista;
            _crudPedido = crudPedido;
        }

        public void RealizarPagamento(Pedido pedido)
        {
            Console.WriteLine($"Total a ser pago: ");
            pedido.calcularValorTotal();
            Console.WriteLine("1. Pagamento a vista");
            Console.WriteLine("2. Pagamento a prazo");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    PagamentoAVista pagamentoVista = new(pedido);
                    _crudPagamentoAVista.AdicionarPagamentoAVista(pagamentoVista);
                    pedido.PediodoConcluido();
                    _crudPedido.AtualizarStatusPedido(pedido);
                    break;
                case "2":
                    Console.Write("Selecione a quantia de parcelas: ");
                    int parcelas = QuantidadeParcelas(12);
                    PagamentoAPrazo pagamentoPrazo = new(pedido, parcelas);
                    _crudPagamentoAPrazo.AdicionarPagamentoAPrazo(pagamentoPrazo);
                    _crudPedido.AtualizarStatusPedido(pedido);
                    pedido.PediodoConcluido();
                    break;
            }

        }
        int QuantidadeParcelas(int maximoParcelas){
            int parcelas;
            while(true)
            {
                parcelas = _interacaoValidacao.ReceberValorNatural();
                if(parcelas<=maximoParcelas)
                {
                    break;
                }
                else{
                    Console.WriteLine("Quantidade de parcelas não permitida");
                }
            }
            return parcelas;
        }


    }
}