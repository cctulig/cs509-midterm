namespace atm;

/// <summary>
/// This class provides the current Date
/// Allows current date to be mocked in unit tests
/// </summary>
public class Date : IDate
{
    /// <summary>
    /// Gets current date
    /// </summary>
    /// <returns>Current date</returns>
    public DateTime GetCurrentDate()
    {
        return DateTime.Now;
    }
}
