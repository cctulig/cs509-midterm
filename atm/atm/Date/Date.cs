namespace atm;

public class Date : IDate
{
    public DateTime GetCurrentDate()
    {
        return DateTime.Now;
    }
}