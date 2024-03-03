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
        UserMenu? userPage = null;
        
        DBConnection dbConnection = new DBConnection();

        Console.WriteLine("ATM Application");
        Console.WriteLine("------------------------");
        
        while (true)
        {
            Console.WriteLine("Sign in!");

            Console.Write("Enter login: ");
            string login = Console.ReadLine();

            Console.Write("Enter Pin code: ");
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
                    userPage = new AdminMenu();
                }
                else
                {
                    userPage = new CustomerMenu(userLoginData.Id);
                }
                userPage.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}