namespace atm;

public class Customer : User
{
    private int _accountNumber = 12;
    private string _name = "test";
    private int _balance = 100000;
    private bool _active = true;
    
    public void WithdrawCash(string cash)
    {
        int withdrawAmount;
        if (!Int32.TryParse(cash, out withdrawAmount))
        {
            Console.WriteLine("Invalid number entered");
            return;
        }

        if (withdrawAmount <= 0)
        {
            Console.WriteLine("Must enter an amount greater than 0");
            return;
        }

        if (withdrawAmount > _balance)
        {
            Console.WriteLine("Withdrawn amount exceeds current balance");
            return;
        }

        _balance -= withdrawAmount;
        UpdateCustomerBalance();
        Console.WriteLine($"Cash Successfully Withdrawn\nAccount #{_accountNumber}\nDate: 01/29/2024\nWithdrawn: {withdrawAmount}\nBalance: {_balance}");
    }
    
    public void DepositCash(string cash)
    {
        int depositAmount;
        if (!Int32.TryParse(cash, out depositAmount))
        {
            Console.WriteLine("Invalid number entered");
            return;
        }

        if (depositAmount <= 0)
        {
            Console.WriteLine("Must enter an amount greater than 0");
            return;
        }
        
        _balance += depositAmount;
        UpdateCustomerBalance();
        Console.WriteLine($"Cash Deposited Successfully.\nAccount #{_accountNumber}\nDate: 01/29/2024\nDeposited: {depositAmount}\nBalance: {_balance}");
    }
    
    public void DisplayBalance()
    {
        Console.WriteLine($"Account #{_accountNumber}\nDate: 01/29/2024\nBalance: {_balance}");
    }
    
    public void DisplayAccountInformation()
    {
        Console.WriteLine($"Account # {_accountNumber}\nHolder: {_name}\nBalance: {_balance}\nStatus: {_active}\nLogin: {_username}\nPin Code: {_pin}");
    }

    private void UpdateCustomerBalance()
    {
        // Database stuff
    }
}