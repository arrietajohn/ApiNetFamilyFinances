using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IIncomeSourceRepository
{
    IncomeSource GetIncomeSourceById(int incomeSourceId);
    IEnumerable<IncomeSource> GetAllIncomeSources();
    void AddIncomeSource(IncomeSource incomeSource);
    void UpdateIncomeSource(IncomeSource incomeSource);
    void DeleteIncomeSource(int incomeSourceId);
}
