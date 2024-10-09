namespace FamilyFinances.Business.Exceptions;
public class SavingsBagClosedException : Exception
{
    public SavingsBagClosedException(int savingsBagId)
        : base($"Savings bag with ID '{savingsBagId}' is closed and cannot accept contributions.")
    {
    }
}
