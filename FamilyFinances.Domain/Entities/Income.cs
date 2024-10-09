namespace FamilyFinances.Domain.Entities;

public class Income
{
    public int IncomeId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Details { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Member y IncomeSource
    public int MemberId { get; set; }
    public Member Member { get; set; }

    public int IncomeSourceId { get; set; }
    public IncomeSource IncomeSource { get; set; }

    // Constructores
    public Income() { }

    public Income(string name, decimal amount, int memberId, int incomeSourceId)
    {
        Name = name;
        Amount = amount;
        MemberId = memberId;
        IncomeSourceId = incomeSourceId;
    }

    public Income(int incomeId, string name, decimal amount, int memberId, int incomeSourceId, bool isActive)
    {
        IncomeId = incomeId;
        Name = name;
        Amount = amount;
        MemberId = memberId;
        IncomeSourceId = incomeSourceId;
        IsActive = isActive;
    }
}
