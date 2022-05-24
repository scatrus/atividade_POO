namespace atividade;

public class Pedido
{
    public int pedidoId;
    public DateTime dataEmissao;
    public int quantidadeDoProduto;
    public float valorDoProduto;
    public string descricaoDoProduto;

    public float calcularPrecoTotal(float valorDoProduto)
    {
        var total =  quantidadeDoProduto * valorDoProduto;
        return total;
    }
    public void imprimirPedido(string tipoFuncionario)
    {
        Console.WriteLine($"N° do Pedido: {pedidoId}");
        Console.WriteLine($"Data do Pedido: {dataEmissao.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Descrição do Produto: {descricaoDoProduto}");
        Console.WriteLine($"Quantidade do Produto: {quantidadeDoProduto}");
        Console.WriteLine($"Valor do Produto: R$ {valorDoProduto:0.00##}");
        Console.WriteLine($"Valor Total do Pedido: R$ {calcularPrecoTotal(valorDoProduto):0.00##}");
        
        if (tipoFuncionario == "gerente")
        {
            Gerente gerente = new Gerente();
            var precoComDesconto = Convert.ToSingle(gerente.calcularDescontoMaior(valorDoProduto));
            Console.WriteLine($"Valor Total do Pedido com Desconto: R$ {calcularPrecoTotal(precoComDesconto):0.00##}\n");
        }
        else if (tipoFuncionario == "estagiario")
        {
            Estagiario estagiario = new Estagiario();
            var precoComDesconto = Convert.ToSingle(estagiario.CalcularDescontoMenor(valorDoProduto));
            Console.WriteLine($"Valor Total do Pedido com Desconto: R$ {calcularPrecoTotal(precoComDesconto):0.00##}\n");

        }
    }
    
    
}
