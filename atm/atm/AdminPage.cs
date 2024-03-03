namespace atm;

public class AdminPage : UserPage
{
    private Dictionary<int, MenuOption> _optionMap;
    private DBConnection _db;
    private InputValidator _inputValidator;
    private LoginState _loginState = LoginState.SIGNED_IN;
    

    public AdminPage()
    {
        _db = new DBConnection();
        _inputValidator = new InputValidator();
        _optionMap = new Dictionary<int, MenuOption>();
    
        _optionMap.Add(1, new CreateAccountOption(_db, _inputValidator));
        _optionMap.Add(2, new DeleteAccountOption(_db, _inputValidator));
        _optionMap.Add(3, new UpdateAccountOption(_db, _inputValidator));
        _optionMap.Add(4, new SearchAccountOption(_db, _inputValidator));
        _optionMap.Add(5, new ExitOption(_db, _inputValidator));
    }

    public override void Run()
    {
        while (_loginState == LoginState.SIGNED_IN)
        {
            Console.WriteLine("1----Create New Account\r\n2----Delete Existing Account\r\n3----Update Account Information\r\n4----Search for Account\r\n5----Exit\r\n");
            string optionIndex = Console.ReadLine();
            try
            {
                int validOptionindex = _inputValidator.ConvertOptionIndex(optionIndex, 1, 5);
                _loginState = _optionMap[validOptionindex].TryRun();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}