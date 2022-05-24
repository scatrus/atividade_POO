namespace atividade;

public class Estagiario:Funcionario
{
    public double CalcularDescontoMenor(float valorProduto)
    {
        var valorComDesconto = valorProduto *0.95;
        return valorComDesconto;
    }
}