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
        
        DBConnection dbConnection = new DBConnection();

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

                    try
                    {
                        UserLoginData userLoginData = dbConnection.GetUserLogin(login, pin);
                        
                        if (userLoginData.adminAccount)
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
                        Console.WriteLine(e.Message);
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