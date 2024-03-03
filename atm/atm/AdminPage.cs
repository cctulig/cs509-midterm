namespace atm;

enum AdminState
{
    HOME = 0,
    CREATE_ACCOUNT,
    DELETE_ACCOUNT,
    UPDATE_ACCOUNT,
    SEARCH_ACCOUNT,
    EXIT
}

public class AdminPage(Admin inAdmin) : UserPage
{
    private Admin _admin = inAdmin;
    private AdminState _adminState = AdminState.HOME;

    public override LoginState RunUserStateMachine()
    {
        switch (_adminState)
        {
            case AdminState.HOME:
                Home();
                break;
            case AdminState.CREATE_ACCOUNT:
                CreateAccount();
                break;
            case AdminState.DELETE_ACCOUNT:
                DeleteAccount();
                break;
            case AdminState.UPDATE_ACCOUNT:
                UpdateAccount();
                break;
            case AdminState.SEARCH_ACCOUNT:
                SearchAccount();
                break;
            case AdminState.EXIT:
                Exit();
                return LoginState.SIGNED_OUT;
        }
        
        return LoginState.SIGNED_IN;
    }

    private void Home()
    {
        Console.WriteLine("1----Create New Account\r\n2----Delete Existing Account\r\n3----Update Account Information\r\n4----Search for Account\r\n5----Exit\r\n");
        string stringAdminState = Console.ReadLine();
        int intAdminState;
        
        if (!Int32.TryParse(stringAdminState, out intAdminState))
        {
            Console.WriteLine("Invalid option. You must select options 1-5");
            return;
        }

        if (intAdminState < 1 || intAdminState > 5)
        {
            Console.WriteLine("Invalid option. You must select options 1-5");
            return;
        }

        _adminState = (AdminState)intAdminState;
    }
    
    private void CreateAccount()
    {
        Console.WriteLine("Login: ");
        string login = Console.ReadLine();
        
        Console.WriteLine("Pin Code: ");
        string pin = Console.ReadLine();
        
        Console.WriteLine("Holders Name: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Starting Balance: ");
        string startingBalance = Console.ReadLine();
        
        Console.WriteLine("Status: ");
        string status = Console.ReadLine();
        
        _admin.CreateAccount(login, pin, name, startingBalance, status);
        
        _adminState = AdminState.HOME;
    }
    
    private void DeleteAccount()
    {
        Console.WriteLine("Delete Existing Account");
        string accountNumber = Console.ReadLine();
        _admin.DeleteAccount(accountNumber);
        _adminState = AdminState.HOME;
    }
    
    private void UpdateAccount()
    {
        Console.WriteLine("Enter the Account Number: ");
        string accountNumber = Console.ReadLine();
        int validAccountNumber = _admin.ValidAccountNumber(accountNumber);
        if (validAccountNumber >= 0)
        {
            Console.WriteLine("Login: ");
            string login = Console.ReadLine();
        
            Console.WriteLine("Pin Code: ");
            string pin = Console.ReadLine();
        
            Console.WriteLine("Holders Name: ");
            string name = Console.ReadLine();

            _admin.PrintAccountBalance(validAccountNumber);
        
            Console.WriteLine("Status: ");
            string status = Console.ReadLine();
            
            _admin.UpdateAccount(validAccountNumber, login, pin, name, status);
        }
        
        _adminState = AdminState.HOME;
    }
    
    private void SearchAccount()
    {
        Console.WriteLine("Enter Account number: ");
        string accountNumber = Console.ReadLine();
        _admin.SearchForAccount(accountNumber);
        _adminState = AdminState.HOME;
    }
    
    private void Exit()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}