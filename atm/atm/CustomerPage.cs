
namespace atm;

enum CustomerState
{
    HOME = 0,
    WITHDRAW_CASH,
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
                break;
            case CustomerState.WITHDRAW_CASH:
                break;
            case CustomerState.DISPLAY_BALANCE:
                break;
            case CustomerState.EXIT:
                return LoginState.SIGNED_OUT;
        }
        
        return LoginState.SIGNED_IN;
    }
}