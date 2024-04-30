namespace atm;

/// <summary>
/// This class provides input validation
/// </summary>
public class InputValidator : IInputValidator
{
    /// <summary>
    /// Converts accountNumber from string to int
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
    public int ConvertAccountNumber(string accountNumber)
    {
        if (!Int32.TryParse(accountNumber, out int validAccountNumber))
        {
            throw new InvalidInputException("Account number must be a number");
        }

        return validAccountNumber;
    }

    /// <summary>
    /// Checks if the two provided accountNumbers match
    /// </summary>
    /// <param name="accountNumber1"></param>
    /// <param name="accountNumber2"></param>
    /// <returns>Returns true if they match</returns>
    public bool AccountNumbersMatch(string accountNumber1, string accountNumber2)
    {
        if (!accountNumber1.Equals(accountNumber2))
        {
            throw new InvalidInputException("Second account number does not match first account number");
        }

        return true;
    }

    /// <summary>
    /// Converts pin from string to int
    /// </summary>
    /// <param name="pin"></param>
    /// <returns></returns>
    public int ConvertPIN(string pin)
    {
        if (!Int32.TryParse(pin, out int validPin))
        {
            throw new InvalidInputException("Pin must be a number");
        }

        if (validPin < 10000 || validPin > 99999)
        {
            throw new InvalidInputException("Pin must be between 10000 and 99999");
        }

        return validPin;
    }

    /// <summary>
    /// Converts balance from string to int
    /// </summary>
    /// <param name="balance"></param>
    /// <returns></returns>
    public int ConvertBalance(string balance)
    {
        if (!Int32.TryParse(balance, out int validBalance))
        {
            throw new InvalidInputException("Balance must be a number");
        }

        if (validBalance < 0)
        {
            throw new InvalidInputException("Balance must be at least 0");
        }

        return validBalance;
    }

    /// <summary>
    /// Converts status from string to bool
    /// </summary>
    /// <param name="status"></param>
    /// <returns>Returns true if status is "Active", false if "Disabled"</returns>
    public bool ConvertStatus(string status)
    {
        if (status.Equals("Active"))
        {
            return true;
        }
        else if (status.Equals("Disabled"))
        {
            return false;
        }
        else
        {
            throw new InvalidInputException("Status must either be 'Active' or 'Disabled'");
        }
    }

    /// <summary>
    /// Verifies the provided withdrawAmount is positive and less than or equal to balance
    /// </summary>
    /// <param name="withdrawAmount"></param>
    /// <param name="balance"></param>
    /// <returns></returns>
    public bool ValidWithdrawAmount(int withdrawAmount, int balance)
    {
        if (withdrawAmount > balance)
        {
            throw new InvalidInputException("Withdrawn amount exceeds current balance");
        }

        return true;
    }

    /// <summary>
    /// Converts optionIndex from string to int. Also verifies optionIndex is between minIndex and maxIndex.
    /// </summary>
    /// <param name="optionIndex"></param>
    /// <param name="minIndex"></param>
    /// <param name="maxIndex"></param>
    /// <returns></returns>
    public int ConvertOptionIndex(string optionIndex, int minIndex, int maxIndex)
    {
        if (!Int32.TryParse(optionIndex, out int validOptionIndex))
        {
            throw new InvalidInputException($"Invalid option. You must select options {minIndex}-{maxIndex}");
        }

        if (validOptionIndex < minIndex || validOptionIndex > maxIndex)
        {
            throw new InvalidInputException($"Invalid option. You must select options {minIndex}-{maxIndex}");
        }

        return validOptionIndex;
    }
}