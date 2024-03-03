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

public class AdminPage : UserPage
{
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
        Console.WriteLine("Create New Account");
        string input = Console.ReadLine();
        _adminState = AdminState.HOME;
    }
    
    private void DeleteAccount()
    {
        Console.WriteLine("Delete Existing Account");
        string input = Console.ReadLine();
        _adminState = AdminState.HOME;
    }
    
    private void UpdateAccount()
    {
        Console.WriteLine("Update Account Information");
        string input = Console.ReadLine();
        _adminState = AdminState.HOME;
    }
    
    private void SearchAccount()
    {
        Console.WriteLine("Search for Account");
        string input = Console.ReadLine();
        _adminState = AdminState.HOME;
    }
    
    private void Exit()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}