namespace atm;

public class DepositCashOption(int inCurrentAccountNumber) : CustomerOption(inCurrentAccountNumber)
{
    protected override void Run()
    {
        int balance = _db.GetAccountBalance(_inCurrentAccountNumber);
        
        Console.Write("Enter the cash amount to deposit: ");
        string depositAmount = Console.ReadLine();
        int validDepositAmount = _inputValidator.ConvertBalance(depositAmount);

        int newBalance = _db.UpdateCustomerBalance(_inCurrentAccountNumber, balance + validDepositAmount);
        
        Console.WriteLine($"Cash Deposited Successfully.\nAccount #{_inCurrentAccountNumber}\nDate: 01/29/2024\nDeposited: {depositAmount}\nBalance: {newBalance}");
    }
}