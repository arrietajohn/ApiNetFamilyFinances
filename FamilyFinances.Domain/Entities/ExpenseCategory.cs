namespace FamilyFinances.Domain.Entities;

public class ExpenseCategory
{
    public int ExpenseCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Relación con Expenses: Una categoría puede tener muchos gastos
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    // Constructor por defecto
    public ExpenseCategory() { }

    // Constructor completo
    public ExpenseCategory(int expenseCategoryId, string name, string description, string icon, DateTime createdOn, bool isActive)
    {
        ExpenseCategoryId = expenseCategoryId;
        Name = name;
        Description = description;
        Icon = icon;
        CreatedOn = createdOn;
        IsActive = isActive;
    }

    // Constructor sin ExpenseCategoryId y CreatedOn
    public ExpenseCategory(string name, string description, string icon)
    {
        Name = name;
        Description = description;
        Icon = icon;
        CreatedOn = DateTime.Now;
        IsActive = true;
    }

    // Constructor con valores por defecto para Icon
    public ExpenseCategory(string name, string description)
    {
        Name = name;
        Description = description;
        Icon = "Category.png";
        CreatedOn = DateTime.Now;
        IsActive = true;
    }
}

