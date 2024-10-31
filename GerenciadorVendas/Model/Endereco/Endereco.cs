using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas;

namespace GerenciadorVendas.Modelos
{
    public class Endereco
    {
        public int Id {get; private set;}
        public Pais PaisEndereco{ get; private set; }
        public Estado EstadoEndereco{get; private set;}
        public Cidade CidadeEndereco{get; private set;}
        public string Bairro{get; private set;}
        public string Rua{get; private set;}
        public string Numero{get; private set;}
        public Endereco(Pais paisEndereco, Estado estadoEndereco, Cidade cidadeEndereco, string bairro, string rua, string numero)
        {
            PaisEndereco = paisEndereco;
            EstadoEndereco = estadoEndereco;
            CidadeEndereco = cidadeEndereco;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }

        private Endereco(){}

    }
}