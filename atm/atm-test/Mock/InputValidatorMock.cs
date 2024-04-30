using atm;

namespace atm_test.Mock;

public class InputValidatorMock : IInputValidator
{
    public int ConvertAccountNumber(string accountNumber)
    {
        return 1;
    }

    public bool AccountNumbersMatch(string accountNumber1, string accountNumber2)
    {
        return true;
    }

    public int ConvertPIN(string pin)
    {
        return 12345;
    }

    public int ConvertBalance(string balance)
    {
        return 0;
    }

    public bool ConvertStatus(string status)
    {
        return true;
    }

    public bool ValidWithdrawAmount(int withdrawAmount, int balance)
    {
        return true;
    }

    public int ConvertOptionIndex(string optionIndex, int minIndex, int maxIndex)
    {
        return 1;
    }
}
