namespace atm;

public class WithdrawCashOption(int inCurrentAccountNumber) : CustomerOption(inCurrentAccountNumber)
{
    protected override void Run()
    {
        int balance = _db.GetAccountBalance(_inCurrentAccountNumber);
        
        string withdrawAmount = _userInput.WithdrawAmount();
        int validWithdrawAmount = _inputValidator.ConvertBalance(withdrawAmount);
        
        _inputValidator.ValidWithdrawAmount(validWithdrawAmount, balance);
        
        int newBalance = _db.UpdateCustomerBalance(_inCurrentAccountNumber, balance - validWithdrawAmount);
        
        Console.WriteLine($"Cash Successfully Withdrawn\nAccount #{_inCurrentAccountNumber}\nDate: 01/29/2024\nWithdrawn: {validWithdrawAmount}\nBalance: {newBalance}");
    }
}