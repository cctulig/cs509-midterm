namespace atm;

public class DisplayBalanceOption(int currentAccountNumber) : CustomerOption(currentAccountNumber)
{
    protected override void Run()
    {
        int balance = db.GetAccountBalance(currentAccountNumber);
        
        Console.WriteLine($"Account #{currentAccountNumber}\nDate: {date.GetCurrentDate()}\nBalance: {balance}");
    }
}