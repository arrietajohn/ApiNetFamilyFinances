namespace FamilyFinances.Business.Exceptions;

public class InvalidAmountException : Exception
{
    public InvalidAmountException(decimal amount)
        : base($"The amount '{amount}' is invalid.")
    {
    }
}
