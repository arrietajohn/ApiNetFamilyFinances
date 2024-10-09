namespace FamilyFinances.Business.Exceptions;

public class MemberAlreadyExistsException : Exception
{
    public MemberAlreadyExistsException(string userName)
        : base($"The username '{userName}' is already taken.")
    {
    }

    public MemberAlreadyExistsException(string userName, string email)
        : base($"The username '{userName}' or email '{email}' is already in use.")
    {
    }
}