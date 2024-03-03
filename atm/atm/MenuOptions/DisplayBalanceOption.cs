namespace atm;

public class DisplayBalanceOption(DBConnection inDb, InputValidator inInputValidator, int inCurrentAccountNumber) : CustomerOption(inDb, inInputValidator, inCurrentAccountNumber)
{
    protected override void Run()
    {
        int balance = _db.GetAccountBalance(_inCurrentAccountNumber);
        
        Console.WriteLine($"Account #{_inCurrentAccountNumber}\nDate: 01/29/2024\nBalance: {balance}");
    }
}