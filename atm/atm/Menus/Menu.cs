using System.Reflection;
using Ninject;

namespace atm;

public abstract class Menu
{
    protected IDBConnection _db;
    protected IInputValidator _inputValidator;
    protected IUserInput _userInput;
    
    public Menu()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        
        _db = kernel.Get<IDBConnection>();
        _inputValidator = kernel.Get<IInputValidator>();
        _userInput = kernel.Get<IUserInput>();
    }

    public abstract void Run();
}