namespace atividade;

public class Gerente:Funcionario
{
    private String senha = "123";
    public double calcularDescontoMaior(float valorProduto)
    {
        var valorComDesconto = valorProduto * 0.8;
        return Convert.ToSingle(valorComDesconto);
    }

    public bool checkSenha()
    {
        Console.WriteLine("Digite a senha de usuario:");
        var senha = Console.ReadLine();
        if(senha == "123")
        {
            Console.WriteLine("Login realizado.");
            return true;
        }
        else
        {
            Console.WriteLine("Senha invalida");
            return false;
        }
    }
    
}