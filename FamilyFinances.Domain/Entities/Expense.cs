namespace FamilyFinances.Domain.Entities;

public class Expense
{
    public int ExpenseId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Details { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Member y ExpenseCategory
    public int MemberId { get; set; }
    public Member Member { get; set; }

    public int ExpenseCategoryId { get; set; }
    public ExpenseCategory ExpenseCategory { get; set; }

    // Constructores
    public Expense() { }

    public Expense(string name, decimal amount, int memberId, int expenseCategoryId)
    {
        Name = name;
        Amount = amount;
        MemberId = memberId;
        ExpenseCategoryId = expenseCategoryId;
    }

    public Expense(int expenseId, string name, decimal amount, int memberId, int expenseCategoryId, bool isActive)
    {
        ExpenseId = expenseId;
        Name = name;
        Amount = amount;
        MemberId = memberId;
        ExpenseCategoryId = expenseCategoryId;
        IsActive = isActive;
    }

    // Constructor sin ExpenseId y CreatedOn
    public Expense(DateTime date, string name, decimal amount, string details, int memberId, int expenseCategoryId)
    {
        Date = date;
        Name = name;
        Amount = amount;
        Details = details;
        MemberId = memberId;
        ExpenseCategoryId = expenseCategoryId;
        CreatedOn = DateTime.Now;
        IsActive = true;
    }
}
