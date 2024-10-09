namespace FamilyFinances.Domain.Entities;

public class IncomeSource
{
    public int IncomeSourceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; } = "IncomeSource.png";
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Incomes
    public ICollection<Income> Incomes { get; set; } = new List<Income>();

    // Constructores
    public IncomeSource() { }

    public IncomeSource(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public IncomeSource(int incomeSourceId, string name, string description, string icon, bool isActive)
    {
        IncomeSourceId = incomeSourceId;
        Name = name;
        Description = description;
        Icon = icon;
        IsActive = isActive;
    }
}
