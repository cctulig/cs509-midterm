namespace atm;

public abstract class Menu : IMenu
{
    protected DBConnection _db;
    protected InputValidator _inputValidator;
    
    public Menu()
    {
        _db = new DBConnection();
        _inputValidator = new InputValidator();
    }

    public abstract void Run();
}