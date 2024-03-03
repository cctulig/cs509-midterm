namespace atm;

public class InputValidator
{
    public int ConvertAccountNumber(string accountNumber)
    {
        if (!Int32.TryParse(accountNumber, out int validAccountNumber))
        {
            throw new Exception("Account number must be a number");
        }

        return validAccountNumber;
    }

    public bool AccountNumbersMatch(string accountNumber1, string accountNumber2)
    {
        if (!accountNumber1.Equals(accountNumber2))
        {
            throw new Exception("Second account number does not match first account number");
        }

        return true;
    }

    public int ConvertPIN(string pin)
    {
        if (!Int32.TryParse(pin, out int validPin))
        {
            throw new Exception("Pin must be a number");
        }
        
        if (validPin < 10000 || validPin > 99999)
        {
            throw new Exception("Pin must be between 10000 and 99999");
        }

        return validPin;
    }

    public int ConvertBalance(string balance)
    {
        if (!Int32.TryParse(balance, out int validBalance))
        {
            throw new Exception("Balance must be a number");
        }
        
        if (validBalance < 0)
        {
            throw new Exception("Balance must be at least 0");
        }

        return validBalance;
    }

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
            throw new Exception("Status must either be 'Active' or 'Disabled'");
        }
    }

    public bool ValidWithdrawAmount(int withdrawAmount, int balance)
    {
        if (withdrawAmount > balance)
        {
            throw new Exception("Withdrawn amount exceeds current balance");
        }

        return true;
    }

    public int ConvertOptionIndex(string optionIndex, int minIndex, int maxIndex)
    {
        if (!Int32.TryParse(optionIndex, out int validOptionIndex))
        {
            throw new Exception($"Invalid option. You must select options {minIndex}-{maxIndex}");
        }

        if (minIndex < 1 || maxIndex > 5)
        {
            throw new Exception($"Invalid option. You must select options {minIndex}-{maxIndex}");
        }

        return validOptionIndex;
    }
}