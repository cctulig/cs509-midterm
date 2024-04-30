
namespace atm;

/// <summary>
/// Defines the MenuOptions present for an Customer user
/// </summary>
public class CustomerMenu : UserMenu
{
    public CustomerMenu(int inAccountNumber) : base()
    {
        var currentAccountNumber = inAccountNumber;
        _optionsListText = "\r\n1----Withdraw Cash\r\n2----Deposit Cash\r\n3----Display Balance\r\n4----Exit\r\n";

        _optionMap.Add(1, new WithdrawCashOption(currentAccountNumber));
        _optionMap.Add(2, new DepositCashOption(currentAccountNumber));
        _optionMap.Add(3, new DisplayBalanceOption(currentAccountNumber));
        _optionMap.Add(4, new ExitOption());
    }
}
