namespace atm;

public class Admin : User
{
    public void CreateAccount(string login, string pin, string name, string balance, string status)
    {
        if (!Int32.TryParse(pin, out int newPin))
        {
            Console.WriteLine("Pin must be a number");
            return;
        }
        
        if (newPin < 10000 || newPin > 99999)
        {
            Console.WriteLine("Pin must be between 10000 and 99999");
            return;
        }
        
        if (!Int32.TryParse(balance, out int newBalance))
        {
            Console.WriteLine("Balance must be a number");
            return;
        }
        
        if (newBalance < 0)
        {
            Console.WriteLine("Balance must be at least 0");
            return;
        }

        bool newStatus;
        if (status.Equals("Active"))
        {
            newStatus = true;
        }
        else if (status.Equals("Disabled"))
        {
            newStatus = false;
        }
        else
        {
            Console.WriteLine("Status must either be 'Active' or 'Disabled'");
            return;
        }
        
        // Check login is unique
        // Add account to Database

        int accountNum = 15;
        Console.WriteLine($"Account Successfully Created – the account number assigned is: {accountNum}");
    }

    public void DeleteAccount(string accountNumber)
    {
        if (!Int32.TryParse(accountNumber, out int verifyAccountNumber))
        {
            Console.WriteLine("Account number must be a number");
            return;
        }
        
        // Verify account exists
        // Get account name
        string name = "test";
        
        Console.WriteLine($"You wish to delete the account held by {name}. If this information is correct, please re-enter the account number: ");
        
        string confirmAccountNumber = Console.ReadLine();
        if (!accountNumber.Equals(confirmAccountNumber))
        {
            Console.WriteLine("Second account number does not match first account number");
            return;
        }
        
        // Delete account
        
        Console.WriteLine("Account Deleted Successfully");
    }

    public int ValidAccountNumber(string accountNumber)
    {
        if (!Int32.TryParse(accountNumber, out int verifyAccountNumber))
        {
            Console.WriteLine("Account number must be a number");
            return -1;
        }
        
        // Verify account exists in database
        return verifyAccountNumber;
    }
    
    public void PrintAccountBalance(int accountNumber)
    {
        int accountBalance = 100000;
        
        // Get balance from Database
        
        Console.WriteLine($"Balance: {accountBalance}");
    }

    public void UpdateAccount(int accountNumber, string login, string pin, string name, string status)
    {
        if (!Int32.TryParse(pin, out int newPin))
        {
            Console.WriteLine("Pin must be a number");
            return;
        }
        
        if (newPin < 10000 || newPin > 99999)
        {
            Console.WriteLine("Pin must be between 10000 and 99999");
            return;
        }

        bool newStatus;
        if (status.Equals("Active"))
        {
            newStatus = true;
        }
        else if (status.Equals("Disabled"))
        {
            newStatus = false;
        }
        else
        {
            Console.WriteLine("Status must either be 'Active' or 'Disabled'");
            return;
        }
        
        // Update account data
        
        Console.WriteLine("Account successfully updated.");
    }

    public void SearchForAccount(string accountNumber)
    {
        // Find account from database

        Customer customer = new Customer();
        
        customer.DisplayAccountInformation();
    }
}