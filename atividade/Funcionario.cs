namespace atividade;

public class Funcionario
{
    public int matricula { get; set; } = 123;
    public String Nome { get; set; } ="Ademar";
    public String tipo { get; set; }

    public bool Login()
    {
        Console.WriteLine("\n=====================");
        Console.WriteLine("Selecione o usuario:");
        Console.WriteLine("1 - Estagiario");
        Console.WriteLine("2 - Gerente");
        Console.WriteLine("3 - Sair\n");
        Console.WriteLine("Opção:");

        try
        {
            var login = Int32.Parse(Console.ReadLine());
            Console.Clear();
            if (login == 1)
            {
                var Loja = new Loja();
                var estagiario = new Estagiario();
                Loja.Func.tipo = "estagiario";
                Loja.Menu();

            }
            else if (login == 2)
            {
                var gerente = new Gerente();
                if (gerente.checkSenha()) //senha ok
                {
                    var Loja = new Loja();
                    Loja.Func.tipo = "gerente";
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
        catch (FormatException e)
        {
            Console.Clear();
            Console.WriteLine("Digite uma das opções válidas.");
            Login();
        }

        return true;
    }
}