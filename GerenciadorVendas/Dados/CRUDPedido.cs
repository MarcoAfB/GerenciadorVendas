using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorVendas.Modelos
{
    public class CRUDPedido
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDPedido(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarPedido(Pedido Pedido){
            _context.DBPedido.Add(Pedido);
            _context.SaveChanges();
        }
        public void AtualizarStatusPedido(Pedido pedido){
            Pedido pedido1 = _context.DBPedido.FirstOrDefault(x => x.Id == pedido.Id);
            pedido1.PediodoConcluido();
            _context.SaveChanges();
        }

        public List<Pedido> ListarPedidosCliente(Cliente cliente){
            var Pedidos = _context.DBPedido.Where(e => e.Id == cliente.Id);
            return Pedidos.ToList();
        }

        public List<Cidade> SelecionarTodasCidadesDeterminadoEstado(int IdEstado){
            var Cidade = _context.DBCidade.Where(e => e.EstadodaCidade.Id == IdEstado);
            return Cidade.ToList();
        }
        public int QuantidadePedidosRegistrados(){
            var quantidadePedidos = _context.DBPedido.Count();
            return quantidadePedidos;
        }
        public Pedido BuscarPedidoporID(int id){
            Pedido result = _context.DBPedido.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void DeletarPedido(int id){
            Pedido Pedido = _context.DBPedido.FirstOrDefault(x => x.Id == id);
            _context.DBPedido.Remove(_context.DBPedido.Single(c => c.Id == id));
            _context.SaveChanges();
        
        }
    }
}

/*
        public void AtualizarPedido(Pedido Pedido){
            _context.DBPedido.Update(Pedido); 
            _context.SaveChanges();
        }

        public void AtualizarPedido1(Pedido Pedido){
            ValueTask<Pedido> Pedido1 = _context.DBPedido.FindAsync(Pedido.Id);
            Console.WriteLine("Pedido selecionado");
            if (Pedido1 != null)
            {
                Pedido Pedido2 = new(Pedido1.AsTask().Result.Nome, Pedido1.AsTask().Result.CPF, Pedido1.AsTask().Result.Email, Pedido1.AsTask().Result.Endereco);
                Console.WriteLine("Pedido Existente");
                _context.Entry(Pedido2).CurrentValues.SetValues(Pedido);
                _context.SaveChanges();
            }
        }

        public void AtualizarPedido2(Pedido Pedido){
            Pedido Pedido1 = _context.DBPedido.FirstOrDefault(x => x.Id == Pedido.Id);
            Pedido1.AtualizarNome(Pedido.Nome);
            Pedido1.AtualizarEmail(Pedido.Email);
            _context.SaveChanges();
        }
        */