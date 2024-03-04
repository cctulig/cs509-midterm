namespace atm;

public class UpdateAccountOption  : MenuOption
{
    protected override void Run()
    {
        string accountNumber = _userInput.AccountNumber();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = _db.GetCustomer(validAccountNumber);
        
        string login = _userInput.Login();
        
        string pin = _userInput.PinCode();
        int validPin = _inputValidator.ConvertPIN(pin);
        
        string name = _userInput.HoldersName();
        
        Console.WriteLine($"Balance: {customer.balance}");
        
        string status = _userInput.Status();
        bool active = _inputValidator.ConvertStatus(status);
        
        _db.UpdateAccount(validAccountNumber, login, validPin, name, active);
    }
}