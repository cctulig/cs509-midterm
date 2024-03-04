using atm.Exceptions;

namespace atm;

public class LoginMenu : Menu
{
    public override void Run()
    {
        while (true)
        {
            Console.WriteLine("--- Sign in! ---");
            UserMenu userMenu;
            
            string login = userInput.Login();
            string pin = userInput.PinCode();
            
            try
            {
                int validPin = inputValidator.ConvertPIN(pin);
                UserLoginData userLoginData = db.GetUserLogin(login, validPin);
                
                if (userLoginData.adminAccount)
                {
                    userMenu = new AdminMenu();
                }
                else
                {
                    userMenu = new CustomerMenu(userLoginData.Id);
                }
            }
            catch (ATMException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            userMenu.Run();
        }
    }
}