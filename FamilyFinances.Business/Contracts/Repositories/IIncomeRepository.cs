using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IIncomeRepository
{
    Income GetIncomeById(int incomeId);
    IEnumerable<Income> GetIncomesByMemberId(int memberId);
    void AddIncome(Income income);
    void UpdateIncome(Income income);
    void DeleteIncome(int incomeId);
}