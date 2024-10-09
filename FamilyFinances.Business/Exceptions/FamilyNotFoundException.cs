namespace FamilyFinances.Business.Exceptions;
public class FamilyNotFoundException : Exception
{
    public FamilyNotFoundException(int familyId)
        : base($"Family with ID '{familyId}' was not found.")
    {
    }
}
