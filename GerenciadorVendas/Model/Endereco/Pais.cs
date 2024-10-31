using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{
    public class Pais
    {
        public int Id {get; private set;}
        public string Nome {get; private set;}
        public string Sigla{get; private set;}
        public List<Estado> EstadosdoPais = [];
        public Pais(string nome, string sigla){
            Nome = nome;
            Sigla = sigla;
        }
    }
}