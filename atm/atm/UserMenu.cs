namespace atm;

public abstract class UserMenu
{
    protected Dictionary<int, MenuOption> _optionMap;
    protected DBConnection _db;
    protected InputValidator _inputValidator;
    protected string _optionsListText;

    public UserMenu()
    {
        _db = new DBConnection();
        _inputValidator = new InputValidator();
        _optionMap = new Dictionary<int, MenuOption>();
    }
    
    public void Run()
    {
        LoginState loginState = LoginState.SIGNED_IN;
        
        while (loginState == LoginState.SIGNED_IN)
        {
            Console.WriteLine(_optionsListText);
            string optionIndex = Console.ReadLine();
            try
            {
                int validOptionindex = _inputValidator.ConvertOptionIndex(optionIndex, 1, _optionMap.Count);
                loginState = _optionMap[validOptionindex].TryRun();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}