namespace FamilyFinances.Business.Exceptions;

public class InvalidRoleException : Exception
{
    public InvalidRoleException(string roleName)
        : base($"The role '{roleName}' is invalid.")
    {
    }
}
