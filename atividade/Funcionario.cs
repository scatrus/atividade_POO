namespace atividade;

public class Funcionario
{
    public String nome;
    public int matricula;

    public bool Login()
    {
        Console.WriteLine("Login Selecione o usuário:");
        Console.WriteLine("Selecione o usuário:");
        Console.WriteLine("1 - Estagiário");
        Console.WriteLine("2 - Gerente");
        var login = Int32.Parse(Console.ReadLine());

        if(login == 1)
        {
            Estagiario estagiario = new Estagiario();
            var Loja = new Loja();
            Loja.Menu();
        }else if(login == 2)
        {
            Gerente gerente = new Gerente();
            gerente.checkSenha();
        }

        return true;
    }
}