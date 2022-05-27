namespace atividade;

public class Loja
{
    private List<Pedido> _listPedidos = new List<Pedido>();
    public string? funcionario { get; set; }
    // private Funcionario func { get; set; } = new Funcionario();
    private bool AdicionarPedido(Pedido p)
    {
        _listPedidos.Add(p);
        return true;
    }

    private protected bool DeletarPedido(Pedido p)
    {
        _listPedidos.Remove(p);
        return true;
    }
    
    public static void Main()
    {
        var func = new Funcionario();
        func.Login();
    }
    
    public void Menu()
    {
        
        Console.WriteLine("Funcionário:" + funcionario);
        Console.WriteLine("\nOpção Disponíveis:");
        Console.WriteLine("1 - Inserir Pedido");
        Console.WriteLine("2 - Buscar Pedido");
        Console.WriteLine("3 - Listar Pedido");
        Console.WriteLine("4 - Remover Pedido");
        Console.WriteLine("5 - Alterar Perfil");
        Console.WriteLine("6 - Sair\n");
        Console.WriteLine("Digite a opção Desejada:");
        
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
    
    public void InserirPedido()
    {
        try
        {
            Pedido p = new Pedido();
            Console.WriteLine("Digite o ID do pedido:");
            p.pedidoId = Int32.Parse(Console.ReadLine());
            // Console.WriteLine("Data do pedido:");
            p.dataEmissao = DateTime.Now;
            Console.WriteLine("Descrição do produto:");
            p.descricaoDoProduto = Console.ReadLine();
            Console.WriteLine("Quantidade do produto:");
            p.quantidadeDoProduto = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Valor do produto:");
            p.valorDoProduto = float.Parse(Console.ReadLine());
            
            Console.Clear();
            p.imprimirPedido(funcionario);

            AdicionarPedido(p);
            Console.WriteLine("Pedido Inserido com Sucesso!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void ListarPedido()
    {
            foreach (var pedido in _listPedidos)
            {
                Console.WriteLine($"{pedido.pedidoId} - {pedido.descricaoDoProduto} - {pedido.calcularPrecoTotal(pedido.valorDoProduto)}");
            }
        
    }
    
    public void BuscarPedido()
    {
        Console.WriteLine("Digite o Id do Pedido: ");
        var pedido = Int32.Parse(Console.ReadLine());
        var resultado = _listPedidos.Find(x => x.pedidoId == pedido);
        if (resultado == null)
        {
            Console.WriteLine("Pedido não encontrado!");
        }
        else
        {
            resultado.imprimirPedido(funcionario);
        }
    }
    
    public void RemoverPedido()
    {
        ListarPedido();
        Console.WriteLine("Selecione o id do pedido que deseja deletar.");
        var id = Int32.Parse(Console.ReadLine());
        var pedido = _listPedidos.Find(x => x.pedidoId == id);
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