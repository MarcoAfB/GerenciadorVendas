using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Cliente
    {
        public int Id {get; private set;}
        public string Nome {get; private set;}
        public string CPF{get; private set;}
        public string Email{get; private set;}
        public Endereco Endereco{get; private set;} 
        public List<Pedido> Pedidos{get; private set;} = [];
        public Cliente(string nome, string cpf, string email, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Endereco = endereco;
        }    
        private Cliente(){}
        public void AtualizarNome(string novoNome){
            Nome = novoNome;
        }    
        public void AtualizarEmail(string novoEmail){
            Email = novoEmail;
        } 

        public void AdicionarPedido(Pedido pedido){
            Pedidos.Add(pedido);
        }

    }
}