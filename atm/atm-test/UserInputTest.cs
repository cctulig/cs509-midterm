using atm;
using FluentAssertions;

namespace atm_test;

public class UserInputTest
{
    private string _fakeInput = "fake input";

    [Fact]
    public void TestLogin()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.Login().Should().Be(_fakeInput);
    }

    [Fact]
    public void PinCode()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.PinCode().Should().Be(_fakeInput);
    }

    [Fact]
    public void HoldersName()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.HoldersName().Should().Be(_fakeInput);
    }

    [Fact]
    public void StartingBalance()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.StartingBalance().Should().Be(_fakeInput);
    }

    [Fact]
    public void Status()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.Status().Should().Be(_fakeInput);
    }

    [Fact]
    public void TryDeleteAccountNumber()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.TryDeleteAccountNumber().Should().Be(_fakeInput);
    }

    [Fact]
    public void ConfirmDeleteAccountNumber()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.ConfirmDeleteAccountNumber("Joe").Should().Be(_fakeInput);
    }

    [Fact]
    public void DepositAmount()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.DepositAmount().Should().Be(_fakeInput);
    }

    [Fact]
    public void WithdrawAmount()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.WithdrawAmount().Should().Be(_fakeInput);
    }

    [Fact]
    public void AccountNumber()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.AccountNumber().Should().Be(_fakeInput);
    }

    [Fact]
    public void OptionIndex()
    {
        UserInput userInput = new UserInput();

        Console.SetIn(new StringReader(_fakeInput));

        userInput.OptionIndex("1").Should().Be(_fakeInput);
    }
}