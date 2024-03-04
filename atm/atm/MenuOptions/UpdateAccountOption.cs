namespace atm;

public class UpdateAccountOption  : MenuOption
{
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