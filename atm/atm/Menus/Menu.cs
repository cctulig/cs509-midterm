namespace atm;

public abstract class Menu
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