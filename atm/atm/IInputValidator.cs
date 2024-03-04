namespace atm;

public interface IInputValidator
{
    public int ConvertAccountNumber(string accountNumber);

    public bool AccountNumbersMatch(string accountNumber1, string accountNumber2);

    public int ConvertPIN(string pin);

    public int ConvertBalance(string balance);

    public bool ConvertStatus(string status);

    public bool ValidWithdrawAmount(int withdrawAmount, int balance);

    public int ConvertOptionIndex(string optionIndex, int minIndex, int maxIndex);
}