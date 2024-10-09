namespace FamilyFinances.Business.Exceptions;

public class MemberNotFoundException : Exception
{
    public MemberNotFoundException(int memberId)
        : base($"Member with ID '{memberId}' was not found.")
    {
    }
}
