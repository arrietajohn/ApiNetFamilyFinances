namespace FamilyFinances.Domain.Entities;

public class SavingsBag
{
    public int SavingBagId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal IdealAmount { get; set; }
    public string Purpose { get; set; }
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }

    // Relación con Family: Muchas bolsas de ahorro pueden pertenecer a una familia
    public int FamilyId { get; set; }
    public Family Family { get; set; }

    // Relación con Contributions: Una bolsa de ahorro puede tener muchas contribuciones
    public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

    // Constructor por defecto
    public SavingsBag() { }

    // Constructor completo
    public SavingsBag(int savingBagId, string name, DateTime startDate, DateTime? endDate, decimal idealAmount, string purpose, string status, DateTime creationDate, bool isActive, int familyId)
    {
        SavingBagId = savingBagId;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        IdealAmount = idealAmount;
        Purpose = purpose;
        Status = status;
        CreationDate = creationDate;
        IsActive = isActive;
        FamilyId = familyId;
    }

    // Constructor sin SavingBagId y CreationDate
    public SavingsBag(string name, DateTime startDate, decimal idealAmount, string purpose, string status, int familyId)
    {
        Name = name;
        StartDate = startDate;
        IdealAmount = idealAmount;
        Purpose = purpose;
        Status = status;
        FamilyId = familyId;
        CreationDate = DateTime.Now;
        IsActive = true;
    }
}
