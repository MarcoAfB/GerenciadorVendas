using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoEndereco
    {
        private CRUDPais _crudPais;
        private CRUDEstado _crudEstado;
        private CRUDCidade _crudCidade;
        private CRUDEndereco _crudEndereco;
        private InteracaoValidacao _interacaoValidacao = new();
        
        public InteracaoEndereco(CRUDPais crudPais, CRUDEstado crudEstado, CRUDCidade crudCidade, CRUDEndereco crudEndereco)
        {
            _crudPais = crudPais;
            _crudEstado = crudEstado;
            _crudCidade = crudCidade;
            _crudEndereco = crudEndereco;
        }

        Pais EncontrarPais()
        {   
            List<Pais> paises = _crudPais.SelecionarTodosPaises();
            int posicao=1;
            foreach(Pais pais in paises){
                Console.WriteLine($"{posicao} - {pais.Nome}");
                posicao++;
            }
            Console.WriteLine("Selecione seu país: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < posicao && posicaoSelecionada >= 1)
                {
                    return paises[posicaoSelecionada-1];
                }
                else
                {
                    Console.WriteLine("País selecionado incorretamente:");
                }
            }

        }

        Estado EncontrarEstado(Pais pais)
        {
            List<Estado> estados = _crudEstado.SelecionarTodosEstadosDeterminadoPais(pais.Id);
            int posicao=1;
            foreach(Estado estado in estados){
                Console.WriteLine($"{posicao} - {estado.Nome}");
                posicao++;
            }
            Console.WriteLine("Selecione seu estado: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < posicao && posicaoSelecionada >= 1)
                {
                    return estados[posicaoSelecionada-1];
                }
                else
                {
                    Console.WriteLine("Estado selecionado incorretamente:");
                }
            }
        }

        Cidade EncontrarCidade(Estado estado)
        {
            List<Cidade> cidades = _crudCidade.SelecionarTodasCidadesDeterminadoEstado(estado.Id);
            int posicao=1;
            foreach(Cidade cidade in cidades){
                Console.WriteLine($"{posicao} - {cidade.Nome}");
                posicao++;
            }
            Console.WriteLine("Selecione sua cidade: ");
            while(true)
            {
                int posicaoSelecionada = _interacaoValidacao.ReceberValorInteiro();
                if(posicaoSelecionada < posicao && posicaoSelecionada >= 1)
                {
                    return cidades[posicaoSelecionada-1];
                }
                else
                {
                    Console.WriteLine("Cidade selecionado incorretamente:");
                }
            }
        }

        string EntradaBairro()
        {
            string bairro = _interacaoValidacao.EntradaStringNaoVazia("Insira o nome do bairro: ");
            return bairro;
        }

        string EntradaRua()
        {
            string rua = _interacaoValidacao.EntradaStringNaoVazia("Insira o nome da rua: ");
            return rua;
        }

        string EnderecoNumero()
        {
            Console.WriteLine("Insira o número do endereço: ");
            string numero = _interacaoValidacao.ReceberValorInteiro().ToString();
            return numero;
        }

        public Endereco EntradaEndereco()
        {
            Pais pais = EncontrarPais();
            Estado estado = EncontrarEstado(pais);
            Cidade cidade = EncontrarCidade(estado);
            string bairro = EntradaBairro();
            string rua = EntradaRua();
            string numero = EnderecoNumero();
            Endereco endereco = new(pais, estado, cidade, bairro, rua, numero);
            return endereco;
        }

        public Endereco EnderecoCliente(Cliente cliente)
        {
            Endereco endereco = _crudEndereco.BuscarEnderecoCliente(cliente);
            return endereco;
        }

    }
}