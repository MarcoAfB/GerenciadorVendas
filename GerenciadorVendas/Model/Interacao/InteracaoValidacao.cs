using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class InteracaoValidacao
    {
        public int ReceberValorInteiro()
        {
            int chave;
            while(true){
                try
                {
                    chave = int.Parse(Console.ReadLine());  
                }catch
                {
                    Console.WriteLine("Opção selecionada incorretamente");
                    continue;
                }
                break;
            }
            return chave;
        }
        public int ReceberValorNatural()
        {
            int chave;
            while(true){
                try
                {
                    chave = int.Parse(Console.ReadLine()); 
                    if(chave>=1){
                        return chave;
                    }
                    else{
                        Console.WriteLine("O valor deve ser maior que 0");
                    } 
                }catch
                {
                    Console.WriteLine("Opção selecionada incorretamente");
                    continue;
                }
                break;
            }
            return chave;
        }
        public string EntradaStringNaoVazia(string textoAnunciandoEntradadeDados)
        {
            Validador validador = new();
            string descricaoProduto;
            while(true){
                Console.Write(textoAnunciandoEntradadeDados);
                descricaoProduto = Console.ReadLine();
                try{
                    validador.ValidarStringNaoVazia(descricaoProduto);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return descricaoProduto;
        }

        public double EntradaNumeroDouble()
        {
            Validador validador = new();
            double numero;
            while(true){
                try{
                    numero = double.Parse(Console.ReadLine());
                }   
                catch(Exception e){
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                try{
                    validador.ValidarNumeroPositivo(numero);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    continue;
                }
                break;
            }
            return numero;
        }
    }
}