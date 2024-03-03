namespace atm;

public abstract class UserPage
{
    private string username;
    private int pin;
    private bool admin;
    
    public abstract LoginState RunUserStateMachine();
}