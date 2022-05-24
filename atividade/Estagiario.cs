namespace atividade;

public class Estagiario:Funcionario
{
    public double calcularDescontoMenor(float valorProduto)
    {
        var valorComDesconto = valorProduto *0.95;
        return valorComDesconto;
    }
}