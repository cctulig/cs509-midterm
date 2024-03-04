namespace atm;

public class ExitOption : MenuOption
{
    public ExitOption()
    {
        _loginState = LoginState.SIGNED_OUT;
    }
    
    protected override void Run()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}