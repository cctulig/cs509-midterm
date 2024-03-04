namespace atm;

public class DeleteAccountOption : MenuOption
{
    protected override void Run()
    {
        string accountNumber = userInput.TryDeleteAccountNumber();
        int validAccountNumber = inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = db.GetCustomer(validAccountNumber);
        
        string accountNumber2 = userInput.ConfirmDeleteAccountNumber(customer.name);
        inputValidator.AccountNumbersMatch(accountNumber, accountNumber2);
        
        db.DeleteAccount(validAccountNumber);
        
        Console.WriteLine("Account Deleted Successfully");
    }
}