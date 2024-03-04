namespace atm;

public class SearchAccountOption : MenuOption
{
    protected override void Run()
    {
        string accountNumber = _userInput.AccountNumber();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);
        
        CustomerData customer = _db.GetCustomer(validAccountNumber);
        UserLoginData userLoginData = _db.GetUserLogin(validAccountNumber);
        
        Console.WriteLine($"Account # {customer.Id}\nHolder: {customer.name}\nBalance: {customer.balance}\nActive: {customer.active}\nLogin: {userLoginData.login}\nPin Code: {userLoginData.pin}");
    }
}