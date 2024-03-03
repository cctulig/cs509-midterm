namespace atm;

public abstract class CustomerOption(DBConnection inDb, InputValidator inInputValidator, int inCurrentAccountNumber) : MenuOption(inDb, inInputValidator)
{
    protected int _inCurrentAccountNumber = inCurrentAccountNumber;
}