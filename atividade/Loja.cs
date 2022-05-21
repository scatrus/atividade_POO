namespace atividade;

public class Loja
{
    private List<Pedido> ListPedidos = new List<Pedido>();
    
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
        var Loja = new Loja();
        Loja.Menu();
    }
    
    public void Menu()
    {
        Console.WriteLine("Opção Disponíveis:");
        Console.WriteLine("1 - Inserir Pedido");
        Console.WriteLine("2 - Buscar Pedido");
        Console.WriteLine("3 - Listar Pedido");
        Console.WriteLine("4 - Remover Pedido");
        Console.WriteLine("Digite a opção Desejada:");
        
        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("Inserir Pedido");
                InserirPedido();
                Menu();
                break;
            case "2":
                Console.WriteLine("Buscar Pedido");
                Console.WriteLine("Digite o Id do Pedido: ");
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
        Console.WriteLine("Pedido Inserido com Sucesso!");
        p.imprimirPedido(p.pedidoId);
        AdicionarPedido(p);
        foreach ( var pedido in ListPedidos)
        {
            Console.WriteLine(pedido);
        }
        Console.WriteLine(ListPedidos);
    }
    
    public void ListarPedido()
    {
        foreach ( var pedido in ListPedidos)
        {
            Console.WriteLine($"{pedido.pedidoId} - {pedido.descricaoDoProduto} - {pedido.calcularPrecoTotal()}");
        }
    }
    
    public void BuscarPedido()
    {
        var pedido = Int32.Parse(Console.ReadLine());
        foreach ( var p in ListPedidos)
        {
            if (pedido == p.pedidoId)
            {
                Console.WriteLine(p);
            }
            else
            {
                Console.WriteLine("Pedido não encontrado!");
            }
        }
    }
    
    public void RemoverPedido()
    {
        ListarPedido();
        Console.WriteLine("Selecione o id do pedido que deseja deletar.");
        var id = Int32.Parse(Console.ReadLine());
        var pedido = ListPedidos.Find(x => x.pedidoId == id);
        DeletarPedido(pedido);
        Console.Clear();
        Console.WriteLine("Pedido Removido com Sucesso!");
    }
}