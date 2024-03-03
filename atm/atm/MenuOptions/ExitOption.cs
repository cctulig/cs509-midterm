namespace atm;

public class ExitOption : MenuOption
{
    public ExitOption(DBConnection inDb, InputValidator inInputValidator) : base(inDb, inInputValidator)
    {
        _loginState = LoginState.SIGNED_OUT;
    }
    
    protected override void Run()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}