namespace atm;

/// <summary>
/// Handles communicating with View, input validation, and DAL communication for WithdrawCashOption
/// </summary>
public class WithdrawCashOption : CustomerOption
{
    public WithdrawCashOption(int inCurrentAccountNumber) : base(inCurrentAccountNumber)
    { }
    public WithdrawCashOption(int inCurrentAccountNumber, IDate I_date, IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput)
        : base(inCurrentAccountNumber, I_date, I_db, I_inputValidator, I_userInput) { }
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
