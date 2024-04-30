namespace atm;

/// <summary>
/// This interface provides the current Date
/// Allows current date to be mocked in unit tests
/// </summary>
public interface IDate
{
    /// <summary>
    /// Gets current date
    /// </summary>
    /// <returns>Current date</returns>
    public DateTime GetCurrentDate();
}
