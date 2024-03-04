using System.Reflection;
using atm;
using Ninject;

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("*** ATM Application ***\r\n");
        
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        ILoginMenu loginMenu = kernel.Get<ILoginMenu>();

        loginMenu.Run();
    }
}