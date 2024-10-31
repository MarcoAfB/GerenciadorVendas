using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using GerenciadorVendas.Modelos;

namespace GerenciadorVendas.Modelos
{

    public class InteracaoCliente
    {
        private CRUDCliente _crudCliente;
        private InteracaoValidacao _interacaoValidacao = new();
        private  static CRUDPais _crudPais;
        private static CRUDEstado _crudEstado;
        private static CRUDCidade _crudCidade;
        private static CRUDEndereco _crudEndereco;
        private InteracaoEndereco _interacaoEndereco;
        public InteracaoCliente(ApplicationDbContext DB, InteracaoEndereco interacaoEndereco)
        {
            _crudCliente = new CRUDCliente(DB);
            _crudPais = new CRUDPais(DB);
            _crudEstado = new CRUDEstado(DB);
            _crudCidade = new CRUDCidade(DB);
            _crudEndereco = new CRUDEndereco(DB);
            _interacaoEndereco = interacaoEndereco;

        }


        string EntradaNome()
        {
            Validador validador = new();
            string nome;
            while(true){
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                try{
                    validador.ValidarNomeUsuario(nome);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return nome;
        }

        string EntradaCPF()
        {
            Validador validador = new();
            string cpf;
            while(true){
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                try{
                    validador.ValidarCPF(cpf);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return cpf;
        }

        string EntradaEmail()
        {
            string email;
            Validador validador = new();
            while(true)
            {
                Console.Write("E-mail: ");
                email = Console.ReadLine().Trim();
                try{
                    validador.ValidarEmail(email);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return email;
        }


        string EntradaNomeProduto()
        {
            Validador validador = new();
            string nome;
            while(true){
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                try{
                    validador.ValidarStringNaoVazia(nome);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return nome;
        } 
        public void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Cliente ===");
            string nome = EntradaNome();
            string cpf = EntradaCPF();
            string email = EntradaEmail();
            Endereco endereco = _interacaoEndereco.EntradaEndereco();
            Cliente cliente = new Cliente(nome, cpf, email, endereco);
            _crudCliente.AdicionarCliente(cliente);
            _crudEndereco.AdicionarEndereco(endereco);
            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void ListarNomeClientes(){
            List<Cliente> clientes = _crudCliente.ListarClientes();
            int posicao=0;
            foreach(Cliente cliente in clientes){
                Console.WriteLine($"ID: {posicao} - Nome: {cliente.Nome}");
                posicao++;
            }
            Console.ReadLine();
        }


        public Cliente SelecionarCliente()
        {
            
            List<Cliente> clientes = _crudCliente.ListarClientes();
            int quantidadeClientes = _crudCliente.QuantidadeClientesRegistrados();
            Console.WriteLine("Selecione o Cliente: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < quantidadeClientes && posicaoSelecionada >= 0)
                {
                    return clientes[posicaoSelecionada];
                }
                else
                {
                    Console.WriteLine("Cliente selecionado incorretamente:");
                }
            }
        }

        public void AtualizarCliente(int idCliente)
        {
            int opcao=0;
            Cliente cliente = _crudCliente.BuscarClienteporID(idCliente);
            do{
                if(cliente == null)
                {
                    Console.WriteLine("Cliente não encontrado");
                    break;
                }
                Console.Clear();
                Console.WriteLine("Atualizar");
                Console.WriteLine("Tipo do Produto");
                Console.WriteLine("1. Nome");
                Console.WriteLine("2. E-mail");
                Console.WriteLine("0. Salvar");
                Console.Write("Escolha uma opção: ");
                opcao = _interacaoValidacao.ReceberValorInteiro();
                
                switch(opcao){
                    case 1:
                        string novoNome = EntradaNome();
                        _crudCliente.AtualizarNomeCliente(idCliente, novoNome);
                        break;
                    case 2:
                        string novoEmail = EntradaEmail();
                        _crudCliente.AtualizarEmailCliente(idCliente, novoEmail);
                        break;
                    }
                
            }while(opcao!=0);

            Console.WriteLine("Cliente atualizado com sucesso!");
            Console.ReadLine();

        }

        public void DeletarCliente(int id)
        {
            _crudCliente.DeletarCliente(id);
        }

        public void ListarTodasInformacaoesCliente(Cliente cliente)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Endereco Endereco = _interacaoEndereco.EnderecoCliente(cliente);
            
            Console.WriteLine($"=====ENDERECO====");
            Console.WriteLine($"País: {Endereco.PaisEndereco.Nome}");
            Console.WriteLine($"Estado: {Endereco.EstadoEndereco.Nome}");
            Console.WriteLine($"Cidade: {Endereco.CidadeEndereco.Nome}");
            Console.WriteLine($"Bairro: {Endereco.Bairro}");
            Console.WriteLine($"Rua: {Endereco.Rua}");
            Console.WriteLine($"Numero: {Endereco.Numero}");
            Console.ReadLine();
        }

    }
}
