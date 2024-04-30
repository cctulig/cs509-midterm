using System.Reflection;
using Ninject;

namespace atm;

/// <summary>
/// Handles communicating with View, input validation, and DAL communication for CustomerOption
/// </summary>
public abstract class CustomerOption : MenuOption
{
    protected int currentAccountNumber;
    protected IDate date;

    public CustomerOption(int inCurrentAccountNumber, IDate I_date, IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
        currentAccountNumber = inCurrentAccountNumber;
        date = I_date;
    }

    public CustomerOption(int inCurrentAccountNumber) : base()
    {
        currentAccountNumber = inCurrentAccountNumber;

        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());

        date = kernel.Get<IDate>();
    }
}