namespace FamilyFinances.Domain.Entities;

public class Contribution
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateContributed { get; set; } = DateTime.Now;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Member
    public int MemberId { get; set; }
    public Member Member { get; set; }

    // Relación con Income
    public int IncomeId { get; set; }
    public Income Income { get; set; }

    // Relación con Expense (opcional)
    public int? ExpenseId { get; set; }
    public Expense Expense { get; set; }

    // Relación con SavingsBag
    public int SavingsBagId { get; set; }
    public SavingsBag SavingsBag { get; set; }

    // Constructor sin parámetros requerido por EF Core
    public Contribution() { }

    // Constructor con parámetros
    public Contribution(decimal amount, int savingsBagId, int memberId, int incomeId, int? expenseId = null)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount debe ser mayor que cero.");
        Amount = amount;
        SavingsBagId = savingsBagId;
        MemberId = memberId;
        IncomeId = incomeId;
        ExpenseId = expenseId;
    }
}
