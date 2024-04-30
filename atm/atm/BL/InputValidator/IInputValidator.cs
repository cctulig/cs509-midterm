namespace atm;

/// <summary>
/// This interface provides input validation
/// </summary>
public interface IInputValidator
{
    /// <summary>
    /// Converts accountNumber from string to int
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
    public int ConvertAccountNumber(string accountNumber);

    /// <summary>
    /// Checks if the two provided accountNumbers match
    /// </summary>
    /// <param name="accountNumber1"></param>
    /// <param name="accountNumber2"></param>
    /// <returns>Returns true if they match</returns>
    public bool AccountNumbersMatch(string accountNumber1, string accountNumber2);

    /// <summary>
    /// Converts pin from string to int
    /// </summary>
    /// <param name="pin"></param>
    /// <returns></returns>
    public int ConvertPIN(string pin);

    /// <summary>
    /// Converts balance from string to int
    /// </summary>
    /// <param name="balance"></param>
    /// <returns></returns>
    public int ConvertBalance(string balance);

    /// <summary>
    /// Converts status from string to bool
    /// </summary>
    /// <param name="status"></param>
    /// <returns>Returns true if status is "Active", false if "Disabled"</returns>
    public bool ConvertStatus(string status);

    /// <summary>
    /// Verifies the provided withdrawAmount is positive and less than or equal to balance
    /// </summary>
    /// <param name="withdrawAmount"></param>
    /// <param name="balance"></param>
    /// <returns></returns>
    public bool ValidWithdrawAmount(int withdrawAmount, int balance);

    /// <summary>
    /// Converts optionIndex from string to int. Also verifies optionIndex is between minIndex and maxIndex.
    /// </summary>
    /// <param name="optionIndex"></param>
    /// <param name="minIndex"></param>
    /// <param name="maxIndex"></param>
    /// <returns></returns>
    public int ConvertOptionIndex(string optionIndex, int minIndex, int maxIndex);
}
