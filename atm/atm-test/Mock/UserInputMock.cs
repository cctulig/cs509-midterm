using atm;

namespace atm_test.Mock;

public class UserInputMock : IUserInput
{
    public string Login()
    {
        throw new NotImplementedException();
    }

    public string PinCode()
    {
        throw new NotImplementedException();
    }

    public string HoldersName()
    {
        throw new NotImplementedException();
    }

    public string StartingBalance()
    {
        throw new NotImplementedException();
    }

    public string Status()
    {
        throw new NotImplementedException();
    }

    public string TryDeleteAccountNumber()
    {
        throw new NotImplementedException();
    }

    public string ConfirmDeleteAccountNumber(string name)
    {
        throw new NotImplementedException();
    }

    public string DepositAmount()
    {
        throw new NotImplementedException();
    }

    public string WithdrawAmount()
    {
        throw new NotImplementedException();
    }

    public string AccountNumber()
    {
        throw new NotImplementedException();
    }

    public string OptionIndex(string optionList)
    {
        throw new NotImplementedException();
    }
}