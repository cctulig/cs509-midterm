namespace atm;

public class SearchAccountOption(DBConnection inDb, InputValidator inInputValidator) : MenuOption(inDb, inInputValidator)
{
    protected override void Run()
    {
        Console.Write("Enter the Account Number: ");
        string accountNumber = Console.ReadLine();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);
        
        CustomerData customer = _db.GetCustomer(validAccountNumber);
        UserLoginData userLoginData = _db.GetUserLogin(validAccountNumber);
        
        Console.WriteLine($"Account # {customer.Id}\nHolder: {customer.name}\nBalance: {customer.balance}\nActive: {customer.active}\nLogin: {userLoginData.login}\nPin Code: {userLoginData.pin}");
    }
}