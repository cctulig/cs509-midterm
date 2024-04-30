using System.Reflection;
using Ninject;

namespace atm;

// Responsible for Console Read/Write for Options
public abstract class MenuOption
{
    protected IDBConnection db;
    protected IInputValidator inputValidator;
    protected IUserInput userInput;
    protected LoginState loginState = LoginState.SIGNED_IN;

    public MenuOption()
    {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());

        db = kernel.Get<IDBConnection>();
        inputValidator = kernel.Get<IInputValidator>();
        userInput = kernel.Get<IUserInput>();
    }

    public MenuOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput)
    {
        db = I_db;
        inputValidator = I_inputValidator;
        userInput = I_userInput;
    }

    public LoginState TryRun()
    {
        Run();

        return loginState;
    }

    protected abstract void Run();
}