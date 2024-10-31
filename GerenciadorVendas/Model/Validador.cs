using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class Validador
    {
        public void ValidarNomeUsuario(string nome){
            nome = nome.Trim();
            if(string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome não pode ser vazio");
            }
            if(nome.Any(char.IsDigit)){
                throw new ArgumentException("Nome não pode conter números");
            }
        }

        public void ValidarCPF(string cpf){
            cpf = cpf.Trim();
            if(string.IsNullOrEmpty(cpf)){
                throw new ArgumentException("O cpf não pode ser vazia");
            }
            if(cpf.Length != 11){
                throw new ArgumentException("O CPF deve conter 11 números");
            }
            if(cpf.Any(char.IsLetter)){
                throw new ArgumentException("O cpf não pode conter letras");
            }
        }

        public void ValidarEmail(string email){
            email = email.Trim();
            if(string.IsNullOrEmpty(email)){
                throw new ArgumentException("E-mail não pode ser vazio");
            }
        }

        public void ValidarStringNaoVazia(string nome){
            nome = nome.Trim();
            if(string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O campo não pode ser vazio");
            }
        }

        public void ValidarNumeroPositivo(double preco){
            if(preco <= 0){
                throw new ArgumentException("O preço do produto deve ser positivo");
            }
        }

    }
}