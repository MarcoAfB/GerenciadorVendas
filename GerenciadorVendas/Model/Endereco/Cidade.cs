using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas;
namespace GerenciadorVendas.Modelos
{
    public class Cidade
    {
        public int Id {get; private set;}
        public string Nome{get; private set;}
        public Estado EstadodaCidade{get; private set;}
        public Cidade(string nome, Estado estado){
            Nome = nome;
            estado.CidadesdoEstado.Add(this);
            EstadodaCidade = estado;
        }

        private Cidade(){}
        
    }
}