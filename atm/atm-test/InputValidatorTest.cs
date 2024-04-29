using atm;
using FluentAssertions;

namespace atm_test;

public class InputValidatorTest
{
    [Fact]
    public void TestConvertAccountNumber_1()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertAccountNumber("1").Should().Be(1);
    }
    
    [Fact]
    public void TestConvertAccountNumber_a()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertAccountNumber("a"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Account number must be a number");
    }
    
    [Fact]
    public void TestAccountNumbersMatch_1_1()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.AccountNumbersMatch("1", "1").Should().Be(true);
    }
    
    [Fact]
    public void TestAccountNumbersMatch_1_2()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.AccountNumbersMatch("1", "2"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Second account number does not match first account number");
    }
    
    [Fact]
    public void TestConvertPIN_10000()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertPIN("10000").Should().Be(10000);
    }
    
    [Fact]
    public void TestConvertPIN_99999()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertPIN("99999").Should().Be(99999);
    }
    
    [Fact]
    public void TestConvertPIN_a()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertPIN("a"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Pin must be a number");
    }
    
    [Fact]
    public void TestConvertPIN_9999()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertPIN("9999"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Pin must be between 10000 and 99999");
    }
    
    [Fact]
    public void TestConvertPIN_100000()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertPIN("100000"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Pin must be between 10000 and 99999");
    }
    
    [Fact]
    public void TestConvertBalance_0()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertBalance("0").Should().Be(0);
    }
    
    [Fact]
    public void TestConvertBalance_a()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertBalance("a"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Balance must be a number");
    }
    
    [Fact]
    public void TestConvertBalance_negative1()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertBalance("-1"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Balance must be at least 0");
    }
    
    [Fact]
    public void TestConvertStatus_Active()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertStatus("Active").Should().Be(true);
    }
    
    [Fact]
    public void TestConvertStatus_Disabled()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertStatus("Disabled").Should().Be(false);
    }
    
    [Fact]
    public void TestConvertStatus_a()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertStatus("a"); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Status must either be 'Active' or 'Disabled'");
    }
    
    [Fact]
    public void TestValidWithdrawAmount_1_from_2()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ValidWithdrawAmount(1, 2).Should().Be(true);
    }
    
    [Fact]
    public void TestValidWithdrawAmount_2_from_1()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ValidWithdrawAmount(2, 1); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Withdrawn amount exceeds current balance");
    }
    
    [Fact]
    public void TestConvertOptionIndex_1_between_0_and_2()
    {
        InputValidator inputValidator = new InputValidator();

        inputValidator.ConvertOptionIndex("1", 0, 2).Should().Be(1);
    }
    
    [Fact]
    public void TestConvertOptionIndex_a_between_0_and_2()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertOptionIndex("a", 0, 2); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Invalid option. You must select options 0-2");
    }
    
    [Fact]
    public void TestConvertOptionIndex_3_between_0_and_2()
    {
        InputValidator inputValidator = new InputValidator();
        Action action = () => { var res = inputValidator.ConvertOptionIndex("3", 0, 2); };

        action.Should().Throw<InvalidInputException>()
            .WithMessage("Invalid option. You must select options 0-2");
    }
}