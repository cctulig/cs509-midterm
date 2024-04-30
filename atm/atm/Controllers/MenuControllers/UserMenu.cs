using atm.Exceptions;

namespace atm;

/// <summary>
/// Defines the MenuOptions present for a user
/// </summary>
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
            string optionIndex = userInput.OptionIndex(_optionsListText);
            try
            {
                int validOptionindex = inputValidator.ConvertOptionIndex(optionIndex, 1, _optionMap.Count);
                loginState = _optionMap[validOptionindex].TryRun();
            }
            catch (ATMException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
