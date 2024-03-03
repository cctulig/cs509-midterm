namespace atm;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

public class DB
{
    private MySqlConnection _connection;
    
    public DB()
    {
        string connStr = "server=localhost;user=root;database=cs509midterm;port=3306;password=a";
        _connection = new MySqlConnection(connStr);
    }

    public UserLoginData GetUserLogin(string login, int pin)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        getUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);
        
        return _connection.QueryFirst<UserLoginData>("SELECT * FROM userlogin WHERE login=@login AND pin=@pin;", getUserParameters);
    }
    
    public void CreateAccount(string login, int pin, string name, int startingBalance, bool active)
    {
        var createUserParameters = new DynamicParameters();
        createUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        createUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);
        createUserParameters.Add("adminAccount", false, DbType.Boolean, ParameterDirection.Input);
        
        _connection.Execute("INSERT INTO userlogin (login, pin, adminAccount) VALUES (@login, @pin, @adminAccount)", createUserParameters);

        UserLoginData userLoginData = GetUserLogin(login, pin);
        
        var createCustomerParameters = new DynamicParameters();
        createCustomerParameters.Add("id", userLoginData.Id, DbType.Int32, ParameterDirection.Input);
        createCustomerParameters.Add("name", name, DbType.String, ParameterDirection.Input);
        createCustomerParameters.Add("balance", startingBalance, DbType.Int32, ParameterDirection.Input);
        createCustomerParameters.Add("active", active, DbType.Boolean, ParameterDirection.Input);
        
        _connection.Execute("INSERT INTO customer (id, name, balance, active) VALUES (@id, @name, @balance, @active)", createCustomerParameters);
    }

    public void DeleteAccount(int accountNumber)
    {
        var deleteUserParameters = new DynamicParameters();
        deleteUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);

        _connection.Execute("DELETE FROM customer WHERE id=@id", deleteUserParameters);
        _connection.Execute("DELETE FROM userlogin WHERE id=@id", deleteUserParameters);
    }

    public bool ValidAccountNumber(int accountNumber)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        _connection.QueryFirst<UserLoginData>("SELECT * FROM customer WHERE id=@id;", getUserParameters);

        // Exception will be thrown if it doesnt exist, probably a better way to do this but idk databases
        return true;
    }
    
    public int GetAccountBalance(int accountNumber)
    {
        var getUserParameters = new DynamicParameters();
        getUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        return _connection.QueryFirst<int>("SELECT balance FROM customer WHERE id=@id;", getUserParameters);
    }

    public void UpdateAccount(int accountNumber, string login, int pin, string name, bool active)
    {
        var updateUserParameters = new DynamicParameters();
        updateUserParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        updateUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
        updateUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);
        
        _connection.Execute("UPDATE userlogin set login=@login AND pin=@pin WHERE id=@id", updateUserParameters);

        UserLoginData userLoginData = GetUserLogin(login, pin);
        
        var updateCustomerParameters = new DynamicParameters();
        updateCustomerParameters.Add("id", userLoginData.Id, DbType.Int32, ParameterDirection.Input);
        updateCustomerParameters.Add("name", name, DbType.String, ParameterDirection.Input);
        updateCustomerParameters.Add("active", active, DbType.Boolean, ParameterDirection.Input);
        
        _connection.Execute("UPDATE customer set name=@name AND active=@active WHERE id=@id", updateCustomerParameters);
    }

    public CustomerData GetCustomer(int accountNumber)
    {
        var getCustomerParameters = new DynamicParameters();
        getCustomerParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        
        return _connection.QueryFirst<CustomerData>("SELECT * FROM customer WHERE id=@id;", getCustomerParameters);
    }
    
    public void UpdateCustomerBalance(int accountNumber, int newBalance)
    {
        var updateCustomerParameters = new DynamicParameters();
        updateCustomerParameters.Add("id", accountNumber, DbType.Int32, ParameterDirection.Input);
        updateCustomerParameters.Add("balance", newBalance, DbType.Int32, ParameterDirection.Input);
        
        _connection.Execute("UPDATE customer set balance=@balance WHERE id=@id", updateCustomerParameters);
    }
}