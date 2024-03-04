namespace atm;

public class DeleteAccountOption : MenuOption
{
    protected override void Run()
    {
        string accountNumber = _userInput.TryDeleteAccountNumber();
        int validAccountNumber = _inputValidator.ConvertAccountNumber(accountNumber);

        CustomerData customer = _db.GetCustomer(validAccountNumber);
        
        string accountNumber2 = _userInput.ConfirmDeleteAccountNumber(customer.name);
        _inputValidator.AccountNumbersMatch(accountNumber, accountNumber2);
        
        _db.DeleteAccount(validAccountNumber);
        
        Console.WriteLine("Account Deleted Successfully");
    }
}