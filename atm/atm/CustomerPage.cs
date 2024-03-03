
namespace atm;

enum CustomerState
{
    HOME = 0,
    WITHDRAW_CASH,
    DEPOSIT_CASH,
    DISPLAY_BALANCE,
    EXIT
}

public class CustomerPage : UserPage
{
    private CustomerState _customerState = CustomerState.HOME;

    public override LoginState RunUserStateMachine()
    {
        switch (_customerState)
        {
            case CustomerState.HOME:
                Home();
                break;
            case CustomerState.WITHDRAW_CASH:
                WithdrawCash();
                break;
            case CustomerState.DEPOSIT_CASH:
                DepositCash();
                break;
            case CustomerState.DISPLAY_BALANCE:
                DisplayBalance();
                break;
            case CustomerState.EXIT:
                Exit();
                return LoginState.SIGNED_OUT;
        }
        
        return LoginState.SIGNED_IN;
    }
    
    private void Home()
    {
        Console.WriteLine("1----Withdraw Cash\n2----Deposit Cash\n3----Display Balance\n4----Exit");
        string stringCustomerState = Console.ReadLine();
        int intCustomerState;
        
        if (!Int32.TryParse(stringCustomerState, out intCustomerState))
        {
            Console.WriteLine("Invalid option. You must select options 1-4");
            return;
        }

        if (intCustomerState < 1 || intCustomerState > 4)
        {
            Console.WriteLine("Invalid option. You must select options 1-4");
            return;
        }

        _customerState = (CustomerState)intCustomerState;
    }
    
    private void WithdrawCash()
    {
        Console.WriteLine("Withdraw Cash");
        string input = Console.ReadLine();
        _customerState = CustomerState.HOME;
    }
    
    private void DepositCash()
    {
        Console.WriteLine("Deposit Cash");
        string input = Console.ReadLine();
        _customerState = CustomerState.HOME;
    }
    
    private void DisplayBalance()
    {
        Console.WriteLine("Display Balance");
        string input = Console.ReadLine();
        _customerState = CustomerState.HOME;
    }

    private void Exit()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}