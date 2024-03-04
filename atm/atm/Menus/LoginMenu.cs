namespace atm;

public class LoginMenu : Menu, ILoginMenu
{
    public override void Run()
    {
        while (true)
        {
            Console.WriteLine("--- Sign in! ---");
            UserMenu userMenu;
            
            Console.Write("Enter login: ");
            string login = Console.ReadLine();

            Console.Write("Enter Pin code: ");
            string pin = Console.ReadLine();
            
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