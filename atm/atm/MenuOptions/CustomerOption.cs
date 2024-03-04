using System.Reflection;
using Ninject;

namespace atm;

public abstract class CustomerOption : MenuOption
{
    protected int currentAccountNumber;
    protected IDate date;

    public CustomerOption(int inCurrentAccountNumber)
    {
        currentAccountNumber = inCurrentAccountNumber;
        
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        
        date = kernel.Get<IDate>();
    }
}