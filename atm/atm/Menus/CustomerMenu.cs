
namespace atm;

public class CustomerMenu : UserMenu
{
    private int _currentAccountNumber;
    
    public CustomerMenu(int inAccountNumber) : base()
    {
        _currentAccountNumber = inAccountNumber;
        _optionsListText = "\r\n1----Withdraw Cash\r\n2----Deposit Cash\r\n3----Display Balance\r\n4----Exit";
    
        _optionMap.Add(1, new WithdrawCashOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(2, new DepositCashOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(3, new DisplayBalanceOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(4, new ExitOption(_db, _inputValidator));
    }
}