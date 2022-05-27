namespace atividade;

public class Loja
{
    private List<Pedido> _listPedidos = new List<Pedido>();
    public Funcionario Func { get; set; } = new Funcionario();
    private void AdicionarPedido(Pedido p)
    {
        _listPedidos.Add(p);
    }

    private void DeletarPedido(Pedido p)
    {
        _listPedidos.Remove(p);
    }
    
    public static void Main()
    {
        var func = new Funcionario();
        func.Login();
    }
    
    public void Menu()
    {
        Console.WriteLine("\n========================================================");
        Console.WriteLine($"Funcionário {Func.matricula}:{Func.Nome}-{Func.tipo}");
        Console.WriteLine("========================================================");
        Console.WriteLine("Opção Disponíveis:"); 
        Console.WriteLine("1 - Inserir Pedido");
        Console.WriteLine("2 - Buscar Pedido");
        Console.WriteLine("3 - Listar Pedido");
        Console.WriteLine("4 - Remover Pedido");
        Console.WriteLine("5 - Alterar Perfil");
        Console.WriteLine("6 - Sair\n");
        Console.WriteLine("Digite a opção Desejada:");

        try
        {
            var opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Inserir Pedido");
                    InserirPedido();
                    Menu();
                    break;
                case "2":
                    Console.WriteLine("Buscar Pedido");
                    BuscarPedido();
                    Menu();
                    break;
                case "3":
                    Console.WriteLine("Listar Pedido");
                    ListarPedido();
                    Menu();
                    break;
                case "4":
                    Console.WriteLine("Remover Pedido");
                    RemoverPedido();
                    Menu();
                    break;
                case "5":
                    Main();
                    break;
                case "6":
                    Console.WriteLine("Bye Bye");
                    Environment.Exit(0);
                    break;
                case "":
                    Console.Clear();
                    Console.WriteLine("Não pode ser  vazio.Escolha uma das opções");
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida.Escolha uma das opções");
                    Menu();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            Menu();
        }
    }

    private void InserirPedido()
    {
        try
        {
            Pedido p = new Pedido();
            Console.WriteLine("Digite o ID do pedido:");
            p.PedidoId = Int32.Parse(Console.ReadLine());
            // Console.WriteLine("Data do pedido:");
            p.DataEmissao = DateTime.Now;
            Console.WriteLine("Descrição do produto:");
            p.DescricaoDoProduto = Console.ReadLine();
            Console.WriteLine("Quantidade do produto:");
            p.QuantidadeDoProduto = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Valor do produto:");
            p.ValorDoProduto = float.Parse(Console.ReadLine());
            
            Console.Clear();
            p.ImprimirPedido(Func.tipo);

            AdicionarPedido(p);
            Console.WriteLine("Pedido Inserido com Sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Menu();
        }
    }

    private void ListarPedido()
    {
        if (_listPedidos.Count == 0)
        {
            Console.WriteLine("Não há pedidos cadastrados");
        } 
        foreach (var pedido in _listPedidos)
        { 
                Console.WriteLine($"Pedido:{pedido.PedidoId} - Descrição:{pedido.DescricaoDoProduto} " +
                                  $"- Valor:{pedido.CalcularPrecoTotal(pedido.ValorDoProduto):0.00##}");
        }
    }

    private void BuscarPedido()
    {
        Console.WriteLine("Digite o Id do Pedido: ");
        var pedido = Int32.Parse(Console.ReadLine());
        var resultado = _listPedidos.Find(x => x.PedidoId == pedido);
        if (resultado == null)
        {
            Console.WriteLine("Pedido não encontrado!");
        }
        else
        {
            resultado.ImprimirPedido(Func.ToString());
        }
    }

    private void RemoverPedido()
    {
        ListarPedido();
        Console.WriteLine("Selecione o id do pedido que deseja deletar.");
        var id = Int32.Parse(Console.ReadLine());
        var pedido = _listPedidos.Find(x => x.PedidoId == id);
        if (pedido != null)
        {
            DeletarPedido(pedido);
            Console.WriteLine("Pedido Removido com Sucesso!");
            ListarPedido();
        }
        else
        {
            Console.WriteLine("Pedido não encontrado!");
            RemoverPedido();
        }
        
    }
}