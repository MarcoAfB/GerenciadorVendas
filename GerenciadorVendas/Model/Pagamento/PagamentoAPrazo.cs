using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class PagamentoAPrazo : Pagamento
    {
        public int Prazo { get; private set; }
        public List<Parcela> Parcelas {get; private set;} = [];
        public double ValorCadaParcela{get; private set;}
        private DateTime _dataVencimentoParcelas;
        public PagamentoAPrazo(Pedido pedido, int prazo):base(pedido){
            Prazo = prazo;
            ModelarPagamentoParcela();
        }
        private PagamentoAPrazo():base(){}
        private void ModelarPagamentoParcela()
        {
            for(int i = 1; i<=Prazo;i++){
                _dataVencimentoParcelas = new DateTime(DateTime.Now.Year, DateTime.Now.Month+i, 10);
                Parcelas.Add(new Parcela(_dataVencimentoParcelas, ValorTotal/Prazo, this));
            }
        }
    }

}