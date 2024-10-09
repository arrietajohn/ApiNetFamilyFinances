namespace FamilyFinances.Business.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(decimal balance, decimal requiredAmount)
        : base($"Insufficient funds. Balance: {balance:C}, Required: {requiredAmount:C}")
    {
    }
}
