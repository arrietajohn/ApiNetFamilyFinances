using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IContributionRepository
{
    Contribution GetContributionById(int contributionId);
    IEnumerable<Contribution> GetContributionsBySavingsBagId(int savingsBagId);
    void AddContribution(Contribution contribution);
    void UpdateContribution(Contribution contribution);
    void DeleteContribution(int contributionId);
}
