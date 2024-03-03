
namespace atm;

public class CustomerPage : UserPage
{
    private Dictionary<int, MenuOption> _optionMap;
    private DBConnection _db;
    private InputValidator _inputValidator;
    private LoginState _loginState = LoginState.SIGNED_IN;
    private int _currentAccountNumber;
    

    public CustomerPage(int inAccountNumber)
    {
        _currentAccountNumber = inAccountNumber;
        _db = new DBConnection();
        _inputValidator = new InputValidator();
        _optionMap = new Dictionary<int, MenuOption>();
    
        _optionMap.Add(1, new WithdrawCashOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(2, new DepositCashOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(3, new DisplayBalanceOption(_db, _inputValidator, _currentAccountNumber));
        _optionMap.Add(4, new ExitOption(_db, _inputValidator));
    }

    public override void Run()
    {
        while (_loginState == LoginState.SIGNED_IN)
        {
            Console.WriteLine("\n1----Withdraw Cash\n2----Deposit Cash\n3----Display Balance\n4----Exit");
            string optionIndex = Console.ReadLine();
            try
            {
                int validOptionindex = _inputValidator.ConvertOptionIndex(optionIndex, 1, 4);
                _loginState = _optionMap[validOptionindex].TryRun();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}