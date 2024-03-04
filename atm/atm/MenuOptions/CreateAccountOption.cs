namespace atm;

public class CreateAccountOption() : MenuOption
{
    protected override void Run()
    {
        string login = _userInput.Login();
        
        string pin = _userInput.PinCode();
        int validPin = _inputValidator.ConvertPIN(pin);
        
        string name = _userInput.HoldersName();
        
        string startingBalance = _userInput.StartingBalance();
        int validBalance = _inputValidator.ConvertBalance(startingBalance);
        
        string status = _userInput.Status();
        bool active = _inputValidator.ConvertStatus(status);
        
        int accountId = _db.CreateAccount(login, validPin, name, validBalance, active);

        Console.WriteLine($"Account Successfully Created – the account number assigned is: {accountId}");
    }
}