using System.Reflection;
using Ninject;

namespace atm;

/// <summary>
/// Menus are responsible for:
/// - informing the View which menu to display,
/// - handling user input,
/// - sending user input to the DAL,
/// - navigating to Menus and MenuOptions
/// </summary>
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

    /// <summary>
    /// Runs the Menu
    /// </summary>
    public abstract void Run();
}
