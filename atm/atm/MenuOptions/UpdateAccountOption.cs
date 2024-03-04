namespace atm;

public class UpdateAccountOption  : MenuOption
{
    protected override void Run()
    {
        Console.Write("Enter the Account Number: ");
        string accountNumber = Console.ReadLine();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = _db.GetCustomer(validAccountNumber);
        
        Console.Write("Login: ");
        string login = Console.ReadLine();
        
        Console.Write("Pin Code: ");
        string pin = Console.ReadLine();
        int validPin = _inputValidator.ConvertPIN(pin);
        
        Console.Write("Holders Name: ");
        string name = Console.ReadLine();
        
        Console.WriteLine($"Balance: {customer.balance}");
        
        Console.Write("Status: ");
        string status = Console.ReadLine();
        bool active = _inputValidator.ConvertStatus(status);
        
        _db.UpdateAccount(validAccountNumber, login, validPin, name, active);
    }
}