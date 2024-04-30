namespace atm;

/// <summary>
/// Handles communicating with View, input validation, and DAL communication for DeleteAccountOption
/// </summary>
public class DeleteAccountOption : MenuOption
{
    public DeleteAccountOption() : base() { }
    public DeleteAccountOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
    }

    protected override void Run()
    {
        string accountNumber = userInput.TryDeleteAccountNumber();
        int validAccountNumber = inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = db.GetCustomer(validAccountNumber);

        string accountNumber2 = userInput.ConfirmDeleteAccountNumber(customer.name);
        inputValidator.AccountNumbersMatch(accountNumber, accountNumber2);

        db.DeleteAccount(validAccountNumber);

        Console.WriteLine("Account Deleted Successfully");
    }
}
