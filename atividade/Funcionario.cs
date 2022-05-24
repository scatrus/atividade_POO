namespace atividade;

public class Funcionario
{
    public int matricula { get; set; } = 123;
    private String nome { get; set; } ="Ademar";

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
            var Loja = new Loja();
            Loja.funcionario = "estagiario";
            Loja.Menu("estagiario");
            
        }else if (login == 2)
        {
            Gerente gerente = new Gerente();
            if (gerente.checkSenha()) //senha ok
            {
                var Loja = new Loja();
                Loja.funcionario = "gerente";
                Loja.Menu("gerente");
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