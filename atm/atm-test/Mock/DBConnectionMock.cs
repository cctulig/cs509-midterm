using atm;

namespace atm_test.Mock;

public class DBConnectionMock : IDBConnection
{
    public UserLoginData GetUserLogin(string login, int pin)
    {
        return new UserLoginData(1, "admin", 12345, true);
    }

    public UserLoginData GetUserLogin(int accountNumber)
    {
        return new UserLoginData(1, "admin", 12345, true);
    }

    public int CreateAccount(string login, int pin, string name, int startingBalance, bool active)
    {
        return 10;
    }

    public void DeleteAccount(int accountNumber)
    {
        // do nothing
    }

    public bool ValidAccountNumber(int accountNumber)
    {
        return true;
    }

    public int GetAccountBalance(int accountNumber)
    {
        return 0;
    }

    public void UpdateAccount(int accountNumber, string login, int pin, string name, bool active)
    {
        // do nothing
    }

    public CustomerData GetCustomer(int accountNumber)
    {
        return new CustomerData(2, "customer1", 0, true);
    }

    public int UpdateCustomerBalance(int accountNumber, int newBalance)
    {
        return 0;
    }

    public UserLoginData AttemptSignIn(string login, int pin)
    {
        return new UserLoginData(1, "admin", 12345, true);
    }
}
