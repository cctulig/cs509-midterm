namespace atm;

/// <summary>
/// This interface handles user input
/// </summary>
public interface IUserInput
{
    /// <summary>
    /// Handles and returns login user input
    /// </summary>
    /// <returns></returns>
    public string Login();

    /// <summary>
    /// Handles and returns PinCode user input
    /// </summary>
    /// <returns></returns>
    public string PinCode();

    /// <summary>
    /// Handles and returns HoldersName user input
    /// </summary>
    /// <returns></returns>
    public string HoldersName();

    /// <summary>
    /// Handles and returns StartingBalance user input
    /// </summary>
    /// <returns></returns>
    public string StartingBalance();

    /// <summary>
    /// Handles and returns Status user input
    /// </summary>
    /// <returns></returns>
    public string Status();

    /// <summary>
    /// Handles and returns DeleteAccountNumber user input
    /// </summary>
    /// <returns></returns>
    public string TryDeleteAccountNumber();

    /// <summary>
    /// Handles and returns DeleteAccountNumber confirmation user input
    /// </summary>
    /// <returns></returns>
    public string ConfirmDeleteAccountNumber(string name);

    /// <summary>
    /// Handles and returns DepositAmount user input
    /// </summary>
    /// <returns></returns>
    public string DepositAmount();

    /// <summary>
    /// Handles and returns WithdrawAmount user input
    /// </summary>
    /// <returns></returns>
    public string WithdrawAmount();

    /// <summary>
    /// Handles and returns AccountNumber user input
    /// </summary>
    /// <returns></returns>
    public string AccountNumber();

    /// <summary>
    /// Handles and returns OptionIndex user input
    /// </summary>
    /// <returns></returns>
    public string OptionIndex(string optionList);
}
