namespace FamilyFinances.Business.Exceptions;

public class IncomeSourceNotFoundException : Exception
{
    public IncomeSourceNotFoundException(int incomeSourceId)
        : base($"Income source with ID '{incomeSourceId}' was not found.")
    {
    }
}

