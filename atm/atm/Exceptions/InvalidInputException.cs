using atm.Exceptions;

namespace atm;

public class InvalidInputException(string message) : ATMException(message)
{
}