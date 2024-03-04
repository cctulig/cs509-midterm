using atm.Exceptions;

namespace atm;

public class DatabaseException(string message) : ATMException(message)
{
}