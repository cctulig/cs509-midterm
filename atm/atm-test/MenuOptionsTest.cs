using System.Reflection;
using atm;
using atm_test.Mock;
using Ninject;
using Ninject.Modules;

namespace atm_test;

public class MenuOptionsTest
{
    [Fact]
    public void TestCreateAccountOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();

        CreateAccountOption option = kernel.Get<CreateAccountOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        string expectedOutputStr =
            $"Login: Pin Code: Holders Name: Starting Balance: Status: Account Successfully Created – the account number assigned is: 10\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestDeleteAccountOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();

        DeleteAccountOption option = kernel.Get<DeleteAccountOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        string expectedOutputStr =
            $"Enter the account number to which you want to delete: You wish to delete the account held by customer1. If this information is correct, please re-enter the account number: Account Deleted Successfully\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestDepositCashOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();
        kernel.Rebind<IDate>().To<DateMock>();
        kernel.Bind<DepositCashOption>().ToSelf().WithConstructorArgument(2);

        DepositCashOption option = kernel.Get<DepositCashOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        DateTime expectedDateTime = new DateTime(2024, 4, 19, 0, 0, 0);
        string expectedOutputStr =
            $"Enter the cash amount to deposit: Cash Deposited Successfully.\nAccount #2\nDate: {expectedDateTime}\nDeposited: 10\nBalance: 0\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestDisplayBalanceOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();
        kernel.Rebind<IDate>().To<DateMock>();
        kernel.Bind<DisplayBalanceOption>().ToSelf().WithConstructorArgument(2);

        DisplayBalanceOption option = kernel.Get<DisplayBalanceOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        DateTime expectedDateTime = new DateTime(2024, 4, 19, 0, 0, 0);
        string expectedOutputStr =
            $"Account #2\nDate: {expectedDateTime}\nBalance: 0\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestExitOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();

        ExitOption option = kernel.Get<ExitOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        string expectedOutputStr = "Logging out...\r\n\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_OUT, loginState);
    }
    
    [Fact]
    public void TestSearchAccountOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();

        SearchAccountOption option = kernel.Get<SearchAccountOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        string expectedOutputStr = 
            "Enter the Account Number: Account # 2\nHolder: customer1\nBalance: 0\nActive: Active\nLogin: admin\nPin Code: 12345\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestUpdateAccountOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();

        UpdateAccountOption option = kernel.Get<UpdateAccountOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        string expectedOutputStr = 
            "Enter the Account Number: Login: Pin Code: Holders Name: Balance: 0\r\nStatus: ";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
    
    [Fact]
    public void TestWithdrawCashOption()
    {
        var kernel = new StandardKernel();
        kernel.Rebind<IDBConnection>().To<DBConnectionMock>();
        kernel.Rebind<IInputValidator>().To<InputValidatorMock>();
        kernel.Rebind<IUserInput>().To<UserInputMock>();
        kernel.Rebind<IDate>().To<DateMock>();
        kernel.Bind<WithdrawCashOption>().ToSelf().WithConstructorArgument(2);

        WithdrawCashOption option = kernel.Get<WithdrawCashOption>();

        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        LoginState loginState = option.TryRun();

        DateTime expectedDateTime = new DateTime(2024, 4, 19, 0, 0, 0);
        string expectedOutputStr =
            $"Enter the withdrawal amount: Cash Successfully Withdrawn\nAccount #2\nDate: {expectedDateTime}\nWithdrawn: 0\nBalance: 0\r\n";
        Assert.Equal(expectedOutputStr, writer.ToString());
        Assert.Equal(LoginState.SIGNED_IN, loginState);
    }
}