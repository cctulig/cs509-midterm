using System.Reflection;
using Ninject;

namespace atm;

public class DepositCashOption : CustomerOption
{
    public DepositCashOption(int inCurrentAccountNumber) : base(inCurrentAccountNumber)
    { }
    public DepositCashOption(int inCurrentAccountNumber, IDate I_date, IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput)
        : base(inCurrentAccountNumber, I_date, I_db, I_inputValidator, I_userInput) { }
    protected override void Run()
    {
        int balance = db.GetAccountBalance(currentAccountNumber);

        string depositAmount = userInput.DepositAmount();
        int validDepositAmount = inputValidator.ConvertBalance(depositAmount);

        int newBalance = db.UpdateCustomerBalance(currentAccountNumber, balance + validDepositAmount);

        Console.WriteLine($"Cash Deposited Successfully.\nAccount #{currentAccountNumber}\nDate: {date.GetCurrentDate()}\nDeposited: {depositAmount}\nBalance: {newBalance}");
    }
}