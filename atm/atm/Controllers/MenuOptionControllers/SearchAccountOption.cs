namespace atm;

/// <summary>
/// Handles communicating with View, input validation, and DAL communication for SearchAccountOption
/// </summary>
public class SearchAccountOption : MenuOption
{
    public SearchAccountOption() : base() { }
    public SearchAccountOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
    }

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