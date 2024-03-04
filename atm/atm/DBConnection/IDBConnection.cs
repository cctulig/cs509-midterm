namespace atm;

public interface IDBConnection
{
    public UserLoginData GetUserLogin(string login, int pin);

    public UserLoginData GetUserLogin(int accountNumber);

    public int CreateAccount(string login, int pin, string name, int startingBalance, bool active);

    public void DeleteAccount(int accountNumber);

    public bool ValidAccountNumber(int accountNumber);
    public int GetAccountBalance(int accountNumber);

    public void UpdateAccount(int accountNumber, string login, int pin, string name, bool active);

    public CustomerData GetCustomer(int accountNumber);

    public int UpdateCustomerBalance(int accountNumber, int newBalance);
}