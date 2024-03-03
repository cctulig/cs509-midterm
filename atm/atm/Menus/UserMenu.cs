namespace atm;

public abstract class UserMenu : Menu
{
    protected Dictionary<int, MenuOption> _optionMap;
    protected string _optionsListText;

    public UserMenu() : base()
    {
        _optionMap = new Dictionary<int, MenuOption>();
    }
    
    public override void Run()
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