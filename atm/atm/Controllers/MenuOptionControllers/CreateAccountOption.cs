namespace atm;

public class CreateAccountOption : MenuOption
{
    public CreateAccountOption() : base() { }
    public CreateAccountOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
    }

    protected override void Run()
    {
        string login = userInput.Login();

        string pin = userInput.PinCode();
        int validPin = inputValidator.ConvertPIN(pin);

        string name = userInput.HoldersName();

        string startingBalance = userInput.StartingBalance();
        int validBalance = inputValidator.ConvertBalance(startingBalance);

        string status = userInput.Status();
        bool active = inputValidator.ConvertStatus(status);

        int accountId = db.CreateAccount(login, validPin, name, validBalance, active);

        Console.WriteLine($"Account Successfully Created – the account number assigned is: {accountId}");
    }
}