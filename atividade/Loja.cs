namespace atividade;

public class Loja
{
    private List<Pedido> ListPedidos = new List<Pedido>();
    public Funcionario Func { get; set; } = new Funcionario();
    
    public bool AdicionarPedido(Pedido p)
    {
        ListPedidos.Add(p);
        return true;
    }
    
    public bool DeletarPedido(Pedido p)
    {
        ListPedidos.Remove(p);
        return true;
    }
    
    public static void Main()
    {
        Loja l = new Loja();
        var func = new Funcionario();
        func.Login();
    }
    
    public void Menu()
    {
        Console.WriteLine("\nOpção Disponíveis:");
        Console.WriteLine("1 - Inserir Pedido");
        Console.WriteLine("2 - Buscar Pedido");
        Console.WriteLine("3 - Listar Pedido");
        Console.WriteLine("4 - Remover Pedido");
        Console.WriteLine("5 - Sair\n");
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
                Console.WriteLine("Bye Bye");
                Environment.Exit(0);
                Menu();
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
        Pedido p = new Pedido();
        Console.WriteLine("Digite o ID do pedido:");
        p.pedidoId = Int32.Parse(Console.ReadLine());
        // Console.WriteLine("Data do pedido:");
        p.dataEmissao = DateTime.Now;
        Console.WriteLine("Descrição do produto:");
        p.descricaoDoProduto = Console.ReadLine();
        Console.WriteLine("Quantidade do produto:");
        p.quantidadeDoProduto = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Valor do produto:");
        p.valorDoProduto = float.Parse(Console.ReadLine());
        
        Console.Clear();
        p.imprimirPedido();

        AdicionarPedido(p);
        Console.WriteLine("Pedido Inserido com Sucesso!");
        
    }
    
    public void ListarPedido()
    {
            foreach (var pedido in ListPedidos)
            {
                Console.WriteLine($"{pedido.pedidoId} - {pedido.descricaoDoProduto} - {pedido.calcularPrecoTotal()}");
            }
        
    }
    
    public void BuscarPedido()
    {
        Console.WriteLine("Digite o Id do Pedido: ");
        var pedido = Int32.Parse(Console.ReadLine());
        var resultado = ListPedidos.Find(x => x.pedidoId == pedido);
        if (resultado == null)
        {
            Console.WriteLine("Pedido não encontrado!");
        }
        else
        {
            resultado.imprimirPedido();
        }
    }
    
    public void RemoverPedido()
    {
        ListarPedido();
        Console.WriteLine("Selecione o id do pedido que deseja deletar.");
        var id = Int32.Parse(Console.ReadLine());
        var pedido = ListPedidos.Find(x => x.pedidoId == id);
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