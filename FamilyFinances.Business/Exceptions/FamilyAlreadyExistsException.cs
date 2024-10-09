namespace FamilyFinances.Business.Exceptions;

public class FamilyAlreadyExistsException : Exception
{
    public FamilyAlreadyExistsException(string email)
        : base($"The Email '{email}' is already taken.")
    {
    }

    public FamilyAlreadyExistsException(int familyId, string email)
        : base($"The Family '{familyId}' or email '{email}' is already in use.")
    {
    }
}