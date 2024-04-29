namespace atm;

public class WithdrawCashOption(int currentAccountNumber) : CustomerOption(currentAccountNumber)
{
    protected override void Run()
    {
        int balance = db.GetAccountBalance(currentAccountNumber);
        
        string withdrawAmount = userInput.WithdrawAmount();
        int validWithdrawAmount = inputValidator.ConvertBalance(withdrawAmount);
        
        inputValidator.ValidWithdrawAmount(validWithdrawAmount, balance);
        
        int newBalance = db.UpdateCustomerBalance(currentAccountNumber, balance - validWithdrawAmount);
        
        Console.WriteLine($"Cash Successfully Withdrawn\nAccount #{currentAccountNumber}\nDate: {date.GetCurrentDate()}\nWithdrawn: {validWithdrawAmount}\nBalance: {newBalance}");
    }
}