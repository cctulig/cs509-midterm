namespace atm;

public class SearchAccountOption : MenuOption
{
    protected override void Run()
    {
        string accountNumber = userInput.AccountNumber();
        int validAccountNumber = inputValidator.ConvertAccountNumber(accountNumber);
        
        CustomerData customer = db.GetCustomer(validAccountNumber);
        UserLoginData userLoginData = db.GetUserLogin(validAccountNumber);
        
        Console.WriteLine($"Account # {customer.Id}\nHolder: {customer.name}\nBalance: {customer.balance}\nActive: {FormatActive(customer.active)}\nLogin: {userLoginData.login}\nPin Code: {userLoginData.pin}");
    }

    private string FormatActive(bool active)
    {
        if (active)
        {
            return "Active";
        }
        else
        {
            return "Disabled";
        }
    }
}