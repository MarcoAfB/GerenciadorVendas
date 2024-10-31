using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Estado
    {
        public int Id {get; private set;}
        public string Nome {get; private set;}
        public string Sigla{get; private set;}
        public Pais PaisdoEstado {get; private set;}
        public List<Cidade> CidadesdoEstado {get; private set;} = [];
        public Estado(string nome, string sigla, Pais pais){
            Nome = nome;
            Sigla = sigla;
            PaisdoEstado = pais;
            pais.EstadosdoPais.Add(this);
        }

        public Estado(){}
    }
}