namespace atm;

public class DeleteAccountOption : MenuOption
{
    protected override void Run()
    {
        Console.Write("Enter the account number to which you want to delete: ");

        string accountNumber = Console.ReadLine();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = _db.GetCustomer(validAccountNumber);
        
        Console.Write($"You wish to delete the account held by {customer.name}. If this information is correct, please re-enter the account number: ");
        
        string accountNumber2 = Console.ReadLine();
        _inputValidator.AccountNumbersMatch(accountNumber, accountNumber2);
        
        _db.DeleteAccount(validAccountNumber);
        
        Console.WriteLine("Account Deleted Successfully");
    }
}