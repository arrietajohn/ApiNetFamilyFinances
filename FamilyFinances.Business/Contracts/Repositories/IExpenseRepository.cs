using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IExpenseRepository
{
    Expense GetExpenseById(int expenseId);
    IEnumerable<Expense> GetExpensesByMemberId(int memberId);
    void AddExpense(Expense expense);
    void UpdateExpense(Expense expense);
    void DeleteExpense(int expenseId);
}