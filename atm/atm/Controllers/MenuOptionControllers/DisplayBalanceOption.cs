namespace atm;

public class DisplayBalanceOption : CustomerOption
{
    public DisplayBalanceOption(int inCurrentAccountNumber) : base(inCurrentAccountNumber)
    { }
    public DisplayBalanceOption(int inCurrentAccountNumber, IDate I_date, IDBConnection I_db, IInputValidator I_inputValidator, IUserInput I_userInput)
        : base(inCurrentAccountNumber, I_date, I_db, I_inputValidator, I_userInput) { }

    protected override void Run()
    {
        int balance = db.GetAccountBalance(currentAccountNumber);

        Console.WriteLine($"Account #{currentAccountNumber}\nDate: {date.GetCurrentDate()}\nBalance: {balance}");
    }
}