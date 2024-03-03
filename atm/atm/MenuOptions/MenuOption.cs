namespace atm;

// Responsible for Console Read/Write for Options
public abstract class MenuOption(DBConnection inDb, InputValidator inInputValidator)
{
    protected DBConnection _db = inDb;
    protected InputValidator _inputValidator = inInputValidator;

    public void TryRun()
    {
        try
        {
            Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    protected abstract void Run();
}