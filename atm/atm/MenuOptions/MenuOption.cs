using System.Reflection;
using Ninject;

namespace atm;

// Responsible for Console Read/Write for Options
public abstract class MenuOption
{
    protected IDBConnection _db;
    protected IInputValidator _inputValidator;
    protected LoginState _loginState = LoginState.SIGNED_IN;

    public MenuOption()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        
        _db = kernel.Get<IDBConnection>();
        _inputValidator = kernel.Get<IInputValidator>();
    }

    public LoginState TryRun()
    {
       Run();

        return _loginState;
    }

    protected abstract void Run();
}