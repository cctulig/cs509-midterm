namespace atm;

public class CreateAccountOption(DBConnection inDb, InputValidator inInputValidator) : MenuOption(inDb, inInputValidator)
{
    protected override void Run()
    {
        Console.Write("Login: ");
        string login = Console.ReadLine();
        
        Console.Write("Pin Code: ");
        string pin = Console.ReadLine();
        int validPin = _inputValidator.ConvertPIN(pin);
        
        Console.Write("Holders Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Starting Balance: ");
        string startingBalance = Console.ReadLine();
        int validBalance = _inputValidator.ConvertBalance(startingBalance);
        
        Console.Write("Status: ");
        string status = Console.ReadLine();
        bool active = _inputValidator.ConvertStatus(status);
        
        int accountId = _db.CreateAccount(login, validPin, name, validBalance, active);

        Console.WriteLine($"Account Successfully Created – the account number assigned is: {accountId}");
    }
}