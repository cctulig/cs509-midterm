using System.Reflection;
using Ninject;

namespace atm;

public class LoginMenu : Menu
{
    public override void Run()
    {
        while (true)
        {
            Console.WriteLine("--- Sign in! ---");
            UserMenu userMenu;
            
            string login = _userInput.Login();
            string pin = _userInput.PinCode();
            
            try
            {
                int validPin = _inputValidator.ConvertPIN(pin);
                UserLoginData userLoginData = _db.GetUserLogin(login, validPin);
                
                if (userLoginData.adminAccount)
                {
                    userMenu = new AdminMenu();
                }
                else
                {
                    userMenu = new CustomerMenu(userLoginData.Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            userMenu.Run();
        }
    }
}