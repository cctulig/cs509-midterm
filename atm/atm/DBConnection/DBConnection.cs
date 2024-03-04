namespace atm;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

public class DBConnection : IDBConnection
{
    private MySqlConnection _connection;
    
    public DBConnection()
    {
            string connStr = "server=localhost;user=root;database=cs509midterm;port=3306;password=a";
            _connection = new MySqlConnection(connStr);
    }

    public UserLoginData GetUserLogin(string login, int pin)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        getUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);

        return TryQueryFirst<UserLoginData>("SELECT * FROM userlogin WHERE login=@login AND pin=@pin;", getUserParameters,
            "Unable to find user");
    }
    
    public UserLoginData GetUserLogin(int accountNumber)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);

        return TryQueryFirst<UserLoginData>("SELECT * FROM userlogin WHERE id=@id;", getUserParameters,
            "Unable to find user");
    }
    
    public int CreateAccount(string login, int pin, string name, int startingBalance, bool active)
    {
        var createUserParameters = new DynamicParameters();
        createUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        createUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);
        createUserParameters.Add("adminAccount", false, DbType.Boolean, ParameterDirection.Input);
        createUserParameters.Add("name", name, DbType.String, ParameterDirection.Input);
        createUserParameters.Add("balance", startingBalance, DbType.Int32, ParameterDirection.Input);
        createUserParameters.Add("active", active, DbType.Boolean, ParameterDirection.Input);
        
        TryExecute("BEGIN; INSERT INTO userlogin (login, pin, adminAccount) VALUES(@login, @pin, @adminAccount); INSERT INTO customer (id, name, balance, active) VALUES(LAST_INSERT_ID(),@name, @balance, @active); COMMIT;", createUserParameters, "Unable to create customer account");

        UserLoginData userLoginData = GetUserLogin(login, pin);

        return userLoginData.Id;
    }

    public void DeleteAccount(int accountNumber)
    {
        var deleteUserParameters = new DynamicParameters();
        deleteUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);

        TryExecute("BEGIN; DELETE FROM customer WHERE id=@id; DELETE FROM userlogin WHERE id=@id; COMMIT;", deleteUserParameters, $"Unable to delete user with account number {accountNumber}");
    }

    public bool ValidAccountNumber(int accountNumber)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        TryQueryFirst<UserLoginData>("SELECT * FROM customer WHERE id=@id;", getUserParameters, $"Could not find account number {accountNumber}");

        // Exception will be thrown if it doesnt exist, probably a better way to do this but idk databases
        return true;
    }
    
    public int GetAccountBalance(int accountNumber)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        return TryQueryFirst<int>("SELECT balance FROM customer WHERE id=@id;", getUserParameters, $"Could not get account balance for account number {accountNumber}");
    }

    public void UpdateAccount(int accountNumber, string login, int pin, string name, bool active)
    {
        var updateUserParameters = new DynamicParameters();
        updateUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        updateUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        updateUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);
        
        TryExecute("UPDATE userlogin set login=@login, pin=@pin WHERE id=@id;", updateUserParameters, $"Unable to update account number {accountNumber}");

        UserLoginData userLoginData = GetUserLogin(accountNumber);
        
        var updateCustomerParameters = new DynamicParameters();
        updateCustomerParameters.Add("id", userLoginData.Id, DbType.Int32, ParameterDirection.Input);
        updateCustomerParameters.Add("name", name, DbType.String, ParameterDirection.Input);
        updateCustomerParameters.Add("active", active, DbType.Boolean, ParameterDirection.Input);
        
        TryExecute("UPDATE customer set name=@name, active=@active WHERE id=@id;", updateCustomerParameters, $"Unable to update account number {accountNumber}");
    }

    public CustomerData GetCustomer(int accountNumber)
    {
        var getCustomerParameters = new DynamicParameters();
        getCustomerParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        return TryQueryFirst<CustomerData>("SELECT * FROM customer WHERE id=@id;", getCustomerParameters, $"Unable to get customer for account number {accountNumber}");
    }
    
    public int UpdateCustomerBalance(int accountNumber, int newBalance)
    {
        var updateCustomerParameters = new DynamicParameters();
        updateCustomerParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        updateCustomerParameters.Add("balance", newBalance, DbType.Int32, ParameterDirection.Input);
        
        TryExecute("UPDATE customer set balance=@balance WHERE id=@id;", updateCustomerParameters, $"Unable to update balance for account number {accountNumber}");

        return newBalance;
    }
    
    public UserLoginData AttemptSignIn(string login, int pin)
    {
        UserLoginData loginData = GetUserLogin(login, pin);

        if (loginData.adminAccount)
        {
            return loginData;
        }

        CustomerData customerData = GetCustomer(loginData.Id);

        if (customerData.active)
        {
            return loginData;
        }
        
        throw new DatabaseException("Unable to find user");
    }

    private void TryExecute(string sql, DynamicParameters parameters, string exceptionMsg)
    {
        CheckConnectionState();
        
        try
        {
            _connection.Execute(sql, parameters);
        }
        catch (Exception e)
        {
            throw new DatabaseException(exceptionMsg);
        }
    }
    
    
    private T TryQueryFirst<T>(string sql, DynamicParameters parameters, string exceptionMsg)
    {
        CheckConnectionState();
        
        try
        {
            return _connection.QueryFirst<T>(sql, parameters);
        }
        catch (Exception e)
        {
            throw new DatabaseException(exceptionMsg);
        }
    }

    private void CheckConnectionState()
    {
        try
        {
            _connection.Open();
        }
        catch (Exception e)
        {
            throw new DatabaseException("Warning database not connected!");
        }
    }
}