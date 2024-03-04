using System.Reflection;
using atm;
using Ninject;
using Ninject.Modules;

public class Bindings : NinjectModule
{
    public override void Load()
    {
        Bind<ILoginMenu>().To<LoginMenu>();
    }
}


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