using atm;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** ATM Application ***\r\n");

        LoginMenu loginMenu = new LoginMenu();
        loginMenu.Run();
    }
}