namespace atm;

public interface IUserInput
{
    public string Login();

    public string PinCode();

    public string HoldersName();

    public string StartingBalance();

    public string Status();

    public string TryDeleteAccountNumber();

    public string ConfirmDeleteAccountNumber(string name);

    public string DepositAmount();

    public string WithdrawAmount();

    public string AccountNumber();

    public string OptionIndex(string optionList);
}