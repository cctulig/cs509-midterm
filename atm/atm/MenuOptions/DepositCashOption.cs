namespace atm;

public class DepositCashOption(int currentAccountNumber) : CustomerOption(currentAccountNumber)
{
    protected override void Run()
    {
        int balance = db.GetAccountBalance(currentAccountNumber);
        
        string depositAmount = userInput.DepositAmount();
        int validDepositAmount = inputValidator.ConvertBalance(depositAmount);

        int newBalance = db.UpdateCustomerBalance(currentAccountNumber, balance + validDepositAmount);
        
        Console.WriteLine($"Cash Deposited Successfully.\nAccount #{currentAccountNumber}\nDate: {date.GetCurrentDate()}\nDeposited: {depositAmount}\nBalance: {newBalance}");
    }
}