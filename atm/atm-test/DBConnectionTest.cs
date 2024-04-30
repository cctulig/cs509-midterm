using atm;
using FluentAssertions;

namespace atm_test;

// If the DB was deployed on the cloud these could serve as integration tests
// For now these are just placeholder verifying that no DB connection can be found
public class DBConnectionTest
{
    [Fact]
    public void TestGetUserLogin_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.GetUserLogin("a", 1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestGetUserLogin2_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.GetUserLogin(1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestCreateAccount_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.CreateAccount("a", 1, "b", 0, true); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestDeleteAccount_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { db.DeleteAccount(1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestValidAccountNumber_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.ValidAccountNumber(1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestGetAccountBalance_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.GetAccountBalance(1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestUpdateAccount_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { db.UpdateAccount(1, "a", 2, "b", true); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestGetCustomer_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.GetCustomer(1); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestUpdateCustomerBalance_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.UpdateCustomerBalance(1, 0); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }

    [Fact]
    public void TestAttemptSignIn_Exception()
    {
        DBConnection db = new DBConnection("");
        Action action = () => { var res = db.AttemptSignIn("a", 0); };

        action.Should().Throw<DatabaseException>()
            .WithMessage("Warning database not connected!");
    }
}