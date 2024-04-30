using atm.Exceptions;

namespace atm;

/// <summary>
/// LoginMenu is responsible for:
/// - Informing the View to print a Login screen
/// - Receives user login input
/// - Sends user login data to the DAL
/// - Navigates to user menu on successful login
/// </summary>
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
                UserLoginData userLoginData = db.AttemptSignIn(login, validPin);

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