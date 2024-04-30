namespace atm;

/// <summary>
/// This class handles user input
/// Each use case is split out into a separate function that calls Console.ReadLine()
/// to allow Unit Testing to define custom output for each
/// </summary>
public class UserInput : IUserInput
{
    /// <summary>
    /// Handles and returns login user input
    /// </summary>
    /// <returns></returns>
    public string Login()
    {
        Console.Write("Login: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns PinCode user input
    /// </summary>
    /// <returns></returns>
    public string PinCode()
    {
        Console.Write("Pin Code: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns HoldersName user input
    /// </summary>
    /// <returns></returns>
    public string HoldersName()
    {
        Console.Write("Holders Name: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns StartingBalance user input
    /// </summary>
    /// <returns></returns>
    public string StartingBalance()
    {
        Console.Write("Starting Balance: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns Status user input
    /// </summary>
    /// <returns></returns>
    public string Status()
    {
        Console.Write("Status: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns DeleteAccountNumber user input
    /// </summary>
    /// <returns></returns>
    public string TryDeleteAccountNumber()
    {
        Console.Write("Enter the account number to which you want to delete: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns DeleteAccountNumber confirmation user input
    /// </summary>
    /// <returns></returns>
    public string ConfirmDeleteAccountNumber(string name)
    {
        Console.Write($"You wish to delete the account held by {name}. If this information is correct, please re-enter the account number: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns DepositAmount user input
    /// </summary>
    /// <returns></returns>
    public string DepositAmount()
    {
        Console.Write("Enter the cash amount to deposit: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns WithdrawAmount user input
    /// </summary>
    /// <returns></returns>
    public string WithdrawAmount()
    {
        Console.Write("Enter the withdrawal amount: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns AccountNumber user input
    /// </summary>
    /// <returns></returns>
    public string AccountNumber()
    {
        Console.Write("Enter the Account Number: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Handles and returns OptionIndex user input
    /// </summary>
    /// <returns></returns>
    public string OptionIndex(string optionList)
    {
        Console.Write(optionList);
        return Console.ReadLine();
    }
}
