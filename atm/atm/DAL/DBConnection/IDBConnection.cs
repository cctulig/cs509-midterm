namespace atm;

/// <summary>
/// DAL for DB requests
/// </summary>
public interface IDBConnection
{
    /// <summary>
    /// Gets user from DB that matches provided login and pin
    /// </summary>
    /// <param name="login"></param>
    /// <param name="pin"></param>
    /// <returns>Found user</returns>
    public UserLoginData GetUserLogin(string login, int pin);

    /// <summary>
    /// Gets user from DB that matches provided accountNumber
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns>Found user</returns>
    public UserLoginData GetUserLogin(int accountNumber);

    /// <summary>
    /// Creates account on DB with the provided data
    /// </summary>
    /// <param name="login"></param>
    /// <param name="pin"></param>
    /// <param name="name"></param>
    /// <param name="startingBalance"></param>
    /// <param name="active"></param>
    /// <returns>Account Number</returns>
    public int CreateAccount(string login, int pin, string name, int startingBalance, bool active);

    /// <summary>
    /// Deletes account from the DB with the provided accountNumber
    /// </summary>
    /// <param name="accountNumber"></param>
    public void DeleteAccount(int accountNumber);

    /// <summary>
    /// Checks if the provided accountNumber exists in the DB
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns>True if the accountNumber exists</returns>
    public bool ValidAccountNumber(int accountNumber);

    /// <summary>
    /// Gets the account balance for the user with the provided accountNumber in the DB
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns>Account Balance</returns>
    public int GetAccountBalance(int accountNumber);

    /// <summary>
    /// Updates account with provided accountNumber on the DB to have provided data
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="login"></param>
    /// <param name="pin"></param>
    /// <param name="name"></param>
    /// <param name="active"></param>
    public void UpdateAccount(int accountNumber, string login, int pin, string name, bool active);

    /// <summary>
    /// Gets customer with the provided accountNumber from the DB
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns>Found Customer</returns>
    public CustomerData GetCustomer(int accountNumber);

    /// <summary>
    /// Updates the balance of the customer with the provided accountNumber in the DB to the newBalance
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="newBalance"></param>
    /// <returns>New Balance</returns>
    public int UpdateCustomerBalance(int accountNumber, int newBalance);

    /// <summary>
    /// Attempts to find the user in the DB with the provided login and pin
    /// </summary>
    /// <param name="login"></param>
    /// <param name="pin"></param>
    /// <returns>Found User</returns>
    public UserLoginData AttemptSignIn(string login, int pin);
}
