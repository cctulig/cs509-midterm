namespace atm;

public abstract class CustomerOption(int inCurrentAccountNumber) : MenuOption
{
    protected int _inCurrentAccountNumber = inCurrentAccountNumber;
}