namespace FamilyFinances.Business.Exceptions;

public class DuplicateContributionException : Exception
{
    public DuplicateContributionException(int contributionId)
        : base($"Contribution with ID '{contributionId}' already exists.")
    {
    }
}


