namespace atm;

public class ExitOption : MenuOption
{
    public ExitOption()
    {
        loginState = LoginState.SIGNED_OUT;
    }
    
    protected override void Run()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}