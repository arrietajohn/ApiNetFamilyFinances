namespace FamilyFinances.Domain.Entities;

public class Contribution
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateContributed { get; set; }

    // Relación con SavingsBag: Muchas contribuciones pueden estar asociadas a una bolsa de ahorro
    public int SavingsBagId { get; set; }
    public SavingsBag SavingsBag { get; set; }

    // Relación con Member: Muchas contribuciones pueden pertenecer a un miembro
    public int MemberId { get; set; }
    public Member Member { get; set; }

    // Relación con Income
    public int IncomeId { get; set; }
    public Income Income { get; set; }

    // Relación opcional con Expense
    public int? ExpenseId { get; set; }
    public Expense Expense { get; set; }

    // Constructor por defecto
    public Contribution() { }

    // Constructor completo
    public Contribution(int id, decimal amount, DateTime dateContributed, int savingsBagId, int memberId, int incomeId, int? expenseId)
    {
        Id = id;
        Amount = amount;
        DateContributed = dateContributed;
        SavingsBagId = savingsBagId;
        MemberId = memberId;
        IncomeId = incomeId;
        ExpenseId = expenseId;
    }

    // Constructor sin Id y DateContributed
    public Contribution(decimal amount, int savingsBagId, int memberId, int incomeId, int? expenseId)
    {
        Amount = amount;
        SavingsBagId = savingsBagId;
        MemberId = memberId;
        IncomeId = incomeId;
        ExpenseId = expenseId;
        DateContributed = DateTime.Now;
    }
}
