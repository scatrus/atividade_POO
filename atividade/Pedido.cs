namespace atividade;

public class Pedido
{
    public int PedidoId;
    public DateTime DataEmissao;
    public int QuantidadeDoProduto;
    public float ValorDoProduto;
    public string? DescricaoDoProduto;
    

    public float CalcularPrecoTotal(float valorDoProduto)
    {
        var total =  QuantidadeDoProduto * valorDoProduto;
        return total;
    }
    public void ImprimirPedido(String tipoFuncionario)
    {
        Console.WriteLine($"N° do Pedido: {PedidoId}");
        Console.WriteLine($"Data do Pedido: {DataEmissao.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Descrição do Produto: {DescricaoDoProduto}");
        Console.WriteLine($"Quantidade do Produto: {QuantidadeDoProduto}");
        Console.WriteLine($"Valor do Produto: R$ {ValorDoProduto:0.00##}");
        Console.WriteLine($"Valor Total do Pedido: R$ {CalcularPrecoTotal(ValorDoProduto):0.00##}");
        
        if (tipoFuncionario == "gerente")
        {
            Gerente gerente = new Gerente();
            var precoComDesconto = Convert.ToSingle(gerente.calcularDescontoMaior(ValorDoProduto));
            Console.WriteLine($"Valor Total do Pedido com Desconto: R$ {CalcularPrecoTotal(precoComDesconto):0.00##}\n");
        }
        else if (tipoFuncionario == "estagiario")
        {
            Estagiario estagiario = new Estagiario();
            var precoComDesconto = Convert.ToSingle(estagiario.CalcularDescontoMenor(ValorDoProduto));
            Console.WriteLine($"Valor Total do Pedido com Desconto: R$ {CalcularPrecoTotal(precoComDesconto):0.00##}\n");

        }
    }
    
    
}
