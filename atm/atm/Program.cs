using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using atm;

public enum LoginState
{
    SIGNED_OUT,
    SIGNED_IN
}

public record UserLogin(int Id, string login, int pin, bool adminAccount);

class Program
{
    static void Main(string[] args)
    {
        LoginState loginState = LoginState.SIGNED_OUT;
        UserPage? userPage = null;
        
        string connStr = "server=localhost;user=root;database=cs509midterm;port=3306;password=a";
        using var connection = new MySqlConnection(connStr);

        Console.WriteLine("ATM Application");
        Console.WriteLine("------------------------");
        
        while (true)
        {
            switch(loginState) { 
                case LoginState.SIGNED_OUT:
                    Console.WriteLine("Sign in!");

                    Console.WriteLine("Enter login:");
                    string login = Console.ReadLine();

                    Console.WriteLine("Enter Pin code:");
                    string pinStr = Console.ReadLine();
                    
                    if (!Int32.TryParse(pinStr, out int pin))
                    {
                        Console.WriteLine("Pin must be a number");
                        continue;
                    }
                    
                    var getUserParameters = new DynamicParameters();
                    getUserParameters.Add("login", login, DbType.String, ParameterDirection.Input);
                    getUserParameters.Add("pin", pin, DbType.Int32, ParameterDirection.Input);

                    try
                    {
                        UserLogin userLogin = connection.QueryFirst<UserLogin>(
                            "SELECT * FROM userlogin WHERE login=@login AND pin=@pin;", getUserParameters);
                        
                        if (userLogin.adminAccount)
                        {
                            userPage = new AdminPage(new Admin());
                        }
                        else
                        {
                            userPage = new CustomerPage(new Customer());
                        }
                        loginState = LoginState.SIGNED_IN;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("User not found");
                    }
                    
                    break;
                case LoginState.SIGNED_IN:
                    if (userPage != null)
                    {
                        loginState = userPage.RunUserStateMachine();
                    }
                    else
                    {
                        loginState = LoginState.SIGNED_OUT;
                    }
                    break;
            }
        }
    }
}