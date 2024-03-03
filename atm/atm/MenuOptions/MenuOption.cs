namespace atm;

// Responsible for Console Read/Write for Options
public abstract class MenuOption(DBConnection inDb, InputValidator inInputValidator)
{
    protected DBConnection _db = inDb;
    protected InputValidator _inputValidator = inInputValidator;
    protected LoginState _loginState = LoginState.SIGNED_IN;

    public LoginState TryRun()
    {
       Run();

        return _loginState;
    }

    protected abstract void Run();
}