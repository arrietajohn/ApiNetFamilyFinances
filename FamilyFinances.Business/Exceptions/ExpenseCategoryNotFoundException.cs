namespace FamilyFinances.Business.Exceptions;

public class ExpenseCategoryNotFoundException : Exception
{
    public ExpenseCategoryNotFoundException(int categoryId)
        : base($"Expense category with ID '{categoryId}' was not found.")
    {
    }
}
