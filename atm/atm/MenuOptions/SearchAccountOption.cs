namespace atm;

public class SearchAccountOption : MenuOption
{
    protected override void Run()
    {
        string accountNumber = userInput.AccountNumber();
        int validAccountNumber = inputValidator.ConvertAccountNumber(accountNumber);
        
        CustomerData customer = db.GetCustomer(validAccountNumber);
        UserLoginData userLoginData = db.GetUserLogin(validAccountNumber);
        
        Console.WriteLine($"Account # {customer.Id}\nHolder: {customer.name}\nBalance: {customer.balance}\nActive: {customer.active}\nLogin: {userLoginData.login}\nPin Code: {userLoginData.pin}");
    }
}