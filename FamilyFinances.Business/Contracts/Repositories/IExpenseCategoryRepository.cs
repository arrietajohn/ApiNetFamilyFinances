using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;

public interface IExpenseCategoryRepository
{
    ExpenseCategory GetExpenseCategoryById(int categoryId);
    IEnumerable<ExpenseCategory> GetAllExpenseCategories();
    void AddExpenseCategory(ExpenseCategory expenseCategory);
    void UpdateExpenseCategory(ExpenseCategory expenseCategory);
    void DeleteExpenseCategory(int categoryId);
}
