namespace atm;

/// <summary>
/// Handles communicating with View, input validation, and DAL communication for UpdateAccountOption
/// </summary>
public class UpdateAccountOption : MenuOption
{
    public UpdateAccountOption() : base() { }
    public UpdateAccountOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
    }
    protected override void Run()
    {
        string accountNumber = userInput.AccountNumber();
        int validAccountNumber = inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = db.GetCustomer(validAccountNumber);

        string login = userInput.Login();

        string pin = userInput.PinCode();
        int validPin = inputValidator.ConvertPIN(pin);

        string name = userInput.HoldersName();

        Console.WriteLine($"Balance: {customer.balance}");

        string status = userInput.Status();
        bool active = inputValidator.ConvertStatus(status);

        db.UpdateAccount(validAccountNumber, login, validPin, name, active);
    }
}
