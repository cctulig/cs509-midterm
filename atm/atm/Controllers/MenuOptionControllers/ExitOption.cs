namespace atm;

/// <summary>
/// Handles communicating with View and changes login state to navigate back to LoginMenu
/// </summary>
public class ExitOption : MenuOption
{
    public ExitOption(IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput) : base(I_db,
        I_inputValidator, I_userInput)
    {
        loginState = LoginState.SIGNED_OUT;
    }
    public ExitOption()
    {
        loginState = LoginState.SIGNED_OUT;
    }

    protected override void Run()
    {
        Console.WriteLine("Logging out...\r\n");
    }
}