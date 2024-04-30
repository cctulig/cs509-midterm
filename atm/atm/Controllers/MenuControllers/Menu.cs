using System.Reflection;
using Ninject;

namespace atm;

public abstract class Menu
{
    protected IDBConnection db;
    protected IInputValidator inputValidator;
    protected IUserInput userInput;

    public Menu()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());

        db = kernel.Get<IDBConnection>();
        inputValidator = kernel.Get<IInputValidator>();
        userInput = kernel.Get<IUserInput>();
    }

    public abstract void Run();
}