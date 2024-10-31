
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using GerenciadorVendas.Modelos;


ApplicationDbContext DB = new();

CRUDCliente crudCliente = new CRUDCliente(DB);
CRUDPais crudPais = new CRUDPais(DB);
CRUDEstado crudEstado = new CRUDEstado(DB);
CRUDCidade crudCidade = new CRUDCidade(DB);
CRUDProdutoRoupa crudProdutoRoupa = new CRUDProdutoRoupa(DB);
CRUDProdutoTenis crudProdutoTenis = new CRUDProdutoTenis(DB);
CRUDPagamentoAPrazo crudPagamentoAPrazo = new CRUDPagamentoAPrazo(DB);
CRUDPagamentoAVista crudPagamentoAVista = new CRUDPagamentoAVista(DB);
CRUDPedido crudPedido = new CRUDPedido(DB);
CRUDEstoque crudEstoque = new CRUDEstoque(DB);
CRUDEndereco crudEndereco = new CRUDEndereco(DB);


InteracaoProdutoRoupa interacaoProdutoRoupa = new(crudProdutoRoupa);
InteracaoProdutoTenis interacaoProdutoTenis = new(crudProdutoTenis);
InteracaoProduto interacaoProduto = new(crudProdutoTenis, crudProdutoRoupa);
InteracaoPedido interacaoPedido = new(crudProdutoTenis, crudProdutoRoupa, crudPagamentoAPrazo, crudPagamentoAVista, crudPedido);
InteracaoPagamento interacaoPagamento = new(crudPagamentoAPrazo, crudPagamentoAVista, crudPedido);
InteracaoEstoque interacaoEstoque = new(crudEstoque, crudProdutoTenis, crudProdutoRoupa);
InteracaoEndereco interacaoEndereco = new(crudPais, crudEstado, crudCidade, crudEndereco);
InteracaoCliente interacaoCliente = new(DB, interacaoEndereco);
string opcao = "1";
while (opcao!="0")
{
    Console.Clear();
    Console.WriteLine("=== Gerenciador de Vendas ===");
    Console.WriteLine("1. Listar Todos os Cliente");
    Console.WriteLine("2. Cadastrar Cliente");
    Console.WriteLine("3. Atualizar Cliente");
    Console.WriteLine("4. Remover Cliente");
    Console.WriteLine("5. Listar Todas as Informações do Cliente");
    Console.WriteLine("6. Listar Todos os Produto");
    Console.WriteLine("7. Cadastrar Produtos");
    Console.WriteLine("8. Atualizar Produtos");
    Console.WriteLine("9. Remover Produtos");
    Console.WriteLine("10. Fazer pedido");
    Console.WriteLine("11. Listar Pedidos do Cliente");
    Console.WriteLine("12. Selecionar Pedido para Pagamento");
    Console.WriteLine("13. Comprar Produtos");

    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");
    opcao = Console.ReadLine();
    Cliente cliente;
    Pedido pedido;
    switch (opcao)
    {
        case "1":
            interacaoCliente.ListarNomeClientes();
            break;
        case "2":
            interacaoCliente.CadastrarCliente();
            break;
        case "3":
            cliente = interacaoCliente.SelecionarCliente();
            interacaoCliente.AtualizarCliente(cliente.Id);
            break;
        case "4":
            cliente = interacaoCliente.SelecionarCliente();
            interacaoCliente.DeletarCliente(cliente.Id);
            break;
        case "5":
            cliente = interacaoCliente.SelecionarCliente();
            interacaoCliente.ListarTodasInformacaoesCliente(cliente);
            break;
        case "6":
            interacaoProduto.ListarTodosProdutos();
            break;
        case "7":
            interacaoProduto.CadastrarProduto();
            break;
        case "8":
            interacaoProduto.AtualizaProduto();
            break;
        case "9":
            interacaoProduto.DeletarProduto();
            break;
        case "10":
            cliente = interacaoCliente.SelecionarCliente();
            interacaoPedido.FazerPedido(cliente);
            break;
        case "11":
            cliente = interacaoCliente.SelecionarCliente();
            interacaoPedido.ListarPedidosCliente(cliente);
            break;
        case "12":
            cliente = interacaoCliente.SelecionarCliente();
            pedido = interacaoPedido.SelecionarPedidoPendenteCliente(cliente);
            interacaoPagamento.RealizarPagamento(pedido);
            break;
        case "13":
            interacaoEstoque.AlterarQuantidadeProduto();
            break;
        case "0":

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}


