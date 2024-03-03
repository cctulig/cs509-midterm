using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using atm;

public enum LoginState
{
    SIGNED_OUT,
    SIGNED_IN
}

class Program
{
    static void Main(string[] args)
    {
        LoginState loginState = LoginState.SIGNED_OUT;
        UserPage? userPage = null;

        Console.WriteLine("ATM Application");
        Console.WriteLine("------------------------");
        
        while (true)
        {
            switch(loginState) { 
                case LoginState.SIGNED_OUT:
                    Console.WriteLine("Sign in!");

                    Console.WriteLine("Enter login:");
                    string username = Console.ReadLine();

                    Console.WriteLine("Enter Pin code:");
                    string password = Console.ReadLine();

                    if (true)
                    {
                        userPage = new AdminPage(new Admin());
                    }
                    else
                    {
                        userPage = new CustomerPage(new Customer());
                    }
                    loginState = LoginState.SIGNED_IN;
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