using atm;
using FluentAssertions;

namespace atm_test;

public class DBConnectionTest
{
    [Fact]
    public void TestGetAccountBalance_4()
    {
        DBConnection db = new DBConnection();

        db.GetAccountBalance(4).Should().Be(0);
    }
}