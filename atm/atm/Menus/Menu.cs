using System.Reflection;
using Ninject;

namespace atm;

public abstract class Menu
{
    protected IDBConnection _db;
    protected IInputValidator _inputValidator;
    
    public Menu()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        
        _db = kernel.Get<IDBConnection>();
        _inputValidator = kernel.Get<IInputValidator>();
    }

    public abstract void Run();
}