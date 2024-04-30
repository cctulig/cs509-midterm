namespace atm;

public class AdminMenu : UserMenu
{
    public AdminMenu() : base()
    {
        _optionsListText = "\r\n1----Create New Account\r\n2----Delete Existing Account\r\n3----Update Account Information\r\n4----Search for Account\r\n5----Exit\r\n";

        _optionMap.Add(1, new CreateAccountOption());
        _optionMap.Add(2, new DeleteAccountOption());
        _optionMap.Add(3, new UpdateAccountOption());
        _optionMap.Add(4, new SearchAccountOption());
        _optionMap.Add(5, new ExitOption());
    }
}