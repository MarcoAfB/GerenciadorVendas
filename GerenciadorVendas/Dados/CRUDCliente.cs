using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorVendas.Modelos
{
    public class CRUDCliente
    {
        private readonly ApplicationDbContext _context;
    
        public CRUDCliente(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente){
            _context.DBCliente.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ListarClientes(){
            var clientes = _context.DBCliente;
            return clientes.ToList();
        }
        public int QuantidadeClientesRegistrados(){
            var quantidadeClientes = _context.DBCliente.Count();
            return quantidadeClientes;
        }
        public Cliente BuscarClienteporID(int id){
            Cliente result = _context.DBCliente.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void AtualizarNomeCliente(int id, string nome){
            Cliente cliente = _context.DBCliente.FirstOrDefault(x => x.Id == id);
            cliente.AtualizarNome(nome);
            _context.SaveChanges();
        }
        public void AtualizarEmailCliente(int id, string email){
            Cliente cliente = _context.DBCliente.FirstOrDefault(x => x.Id == id);
            cliente.AtualizarEmail(email);
            _context.SaveChanges();
        }

        public void DeletarCliente(int id){
            Cliente cliente = _context.DBCliente.FirstOrDefault(x => x.Id == id);
            _context.DBCliente.Remove(_context.DBCliente.Single(c => c.Id == id));
            _context.SaveChanges();
        
        }
    }
}
