namespace FamilyFinances.Business.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string userName)
        : base($"User with username '{userName}' was not found.")
    {
    }
}
