namespace atividade;

public class Funcionario
{
    public String nome;
    public int matricula;

    public bool Login()
    {
        Console.WriteLine("Login");
        Console.WriteLine("Selecione o usuario:");
        Console.WriteLine("1 - Estagiario");
        Console.WriteLine("2 - Gerente");
        Console.WriteLine("3 - Sair");

        var login = Int32.Parse(Console.ReadLine());
        Console.Clear();
        if(login == 1)
        {
            Estagiario estagiario = new Estagiario();
            var Loja = new Loja();
            Loja.Func = estagiario;
            Loja.Menu();
            
        }else if (login == 2)
        {
            Gerente gerente = new Gerente();
            if (gerente.checkSenha()) //senha ok
            {
                var Loja = new Loja();
                Loja.Func = gerente;
                Loja.Menu();
            }
            else
            {
                Login();
            }
        }
        else if (login == 3)
        {
            Console.WriteLine("Programa finalizado!");
        }
        else
        {
            Console.WriteLine("Opção invalida!");
            Login();
        }
        return true;
    }
}