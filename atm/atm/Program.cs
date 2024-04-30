using System.Reflection;
using atm;
using Ninject;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("*** ATM Application ***\r\n");

        LoginMenu loginMenu = new LoginMenu();
        loginMenu.Run();
    }
}
