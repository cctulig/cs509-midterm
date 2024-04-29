using atm;

namespace atm_test.Mock;

public class DateMock : IDate
{
    public DateTime GetCurrentDate()
    {
        return new DateTime(2024, 4, 19, 0, 0, 0);
    }
}