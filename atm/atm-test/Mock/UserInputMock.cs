using atm;

namespace atm_test.Mock;

public class UserInputMock : IUserInput
{
    public string Login()
    {
        Console.Write("Login: ");
        return "admin";
    }

    public string PinCode()
    {
        Console.Write("Pin Code: ");
        return "12345";
    }

    public string HoldersName()
    {
        Console.Write("Holders Name: ");
        return "Joe";
    }

    public string StartingBalance()
    {
        Console.Write("Starting Balance: ");
        return "0";
    }

    public string Status()
    {
        Console.Write("Status: ");
        return "Active";
    }

    public string TryDeleteAccountNumber()
    {
        Console.Write("Enter the account number to which you want to delete: ");
        return "2";
    }
    
    public string ConfirmDeleteAccountNumber(string name)
    {
        Console.Write($"You wish to delete the account held by {name}. If this information is correct, please re-enter the account number: ");
        return "2";
    }

    public string DepositAmount()
    {
        Console.Write("Enter the cash amount to deposit: ");
        return "10";
    }
    
    public string WithdrawAmount()
    {
        Console.Write("Enter the withdrawal amount: ");
        return "10";
    }

    public string AccountNumber()
    {
        Console.Write("Enter the Account Number: ");
        return "2";
    }
    
    public string OptionIndex(string optionList)
    {
        Console.Write(optionList);
        return "1";
    }
}