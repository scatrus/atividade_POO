namespace atividade;

public class Pedido
{
    public int pedidoId;
    public DateTime dataEmissao;
    public int quantidadeDoProduto;
    public float valorDoProduto;
    public string descricaoDoProduto;

    public float calcularPrecoTotal()
    {
        return quantidadeDoProduto * valorDoProduto;
    }
    public void imprimirPedido(int id)
    {
        Console.WriteLine($"N° do Pedido: {pedidoId}");
        Console.WriteLine($"Data do Pedido: {dataEmissao.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Descrição do Produto: {descricaoDoProduto}");
        Console.WriteLine($"Quantidade do Produto: {quantidadeDoProduto}");
        Console.WriteLine($"Valor do Produto: {valorDoProduto:0.00##}");
        Console.WriteLine($"Valor Total do Produto: {calcularPrecoTotal()}");
    }
    
    
}
