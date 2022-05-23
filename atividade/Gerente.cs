namespace atividade;

public class Gerente:Funcionario
{
    private String senha = "123";

    public bool checkSenha()
    {
        Console.WriteLine("Digite a senha de usuário:");
        var senha = Console.ReadLine();
        if(senha == "123")
        {
            Console.WriteLine("Login realizado.");
            return true;
        }
        else
        {
            Console.WriteLine("Senha inválida");
            return false;
        }
    }
    float calcularDescontoMaior(float valorProduto)
    {
        return 0;
    }
}