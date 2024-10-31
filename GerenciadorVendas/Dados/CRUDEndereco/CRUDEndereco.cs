using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorVendas.Modelos
{
    public class CRUDEndereco
    {
        private readonly ApplicationDbContext _context;

        public CRUDEndereco(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AdicionarEndereco(Endereco endereco){
            _context.DBEndereco.Add(endereco);
            _context.SaveChanges();
        }
        public Endereco BuscarEnderecoCliente(Cliente cliente){
            Endereco endereco = _context.DBEndereco.FirstOrDefault(x => x.Id == cliente.Endereco.Id);
            return endereco;
        }

    }
}