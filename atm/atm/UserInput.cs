namespace atm;

public class UserInput : IUserInput
{
    public string Login()
    {
        Console.Write("Login: ");
        return Console.ReadLine();
    }

    public string PinCode()
    {
        Console.Write("Pin Code: ");
        return Console.ReadLine();
    }

    public string HoldersName()
    {
        Console.Write("Holders Name: ");
        return Console.ReadLine();
    }

    public string StartingBalance()
    {
        Console.Write("Starting Balance: ");
        return Console.ReadLine();
    }

    public string Status()
    {
        Console.Write("Status: ");
        return Console.ReadLine();
    }

    public string TryDeleteAccountNumber()
    {
        Console.Write("Enter the account number to which you want to delete: ");
        return Console.ReadLine();
    }
    
    public string ConfirmDeleteAccountNumber(string name)
    {
        Console.Write($"You wish to delete the account held by {name}. If this information is correct, please re-enter the account number: ");
        return Console.ReadLine();
    }

    public string DepositAmount()
    {
        Console.Write("Enter the cash amount to deposit: ");
        return Console.ReadLine();
    }
    
    public string WithdrawAmount()
    {
        Console.Write("Enter the withdrawal amount: ");
        return Console.ReadLine();
    }

    public string AccountNumber()
    {
        Console.Write("Enter the Account Number: ");
        return Console.ReadLine();
    }
    
    public string OptionIndex(string optionList)
    {
        Console.Write(optionList);
        return Console.ReadLine();
    }
}