using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Parcela
    {
        public int Id {get; private set;}
        public DateTime DataVencimento {get; private set;}
        public double ValorPrcela {get; private set;}
        public string SituacaoParcela {get; private set;}
        public PagamentoAPrazo PagamentoPertencente{get; private set;}
        public Parcela(DateTime dataVencimento, double valorPrcela, PagamentoAPrazo pagamentoPertencente)
        {
            DataVencimento = dataVencimento;
            ValorPrcela = valorPrcela;
            PagamentoPertencente = pagamentoPertencente;
        }
        private Parcela(){}

    }
}