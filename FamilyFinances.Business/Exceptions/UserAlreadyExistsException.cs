namespace FamilyFinances.Business.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string userName)
        : base($"The username '{userName}' is already taken.")
    {
    }

    public UserAlreadyExistsException(string userName, string email)
        : base($"The username '{userName}' or email '{email}' is already in use.")
    {
    }
}
