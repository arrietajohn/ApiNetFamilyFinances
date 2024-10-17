using FamilyFinances.Domain.Constants;
using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Domain.Entities;

public class SavingsBag
{

    public int SavingsBagId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public decimal IdealAmount { get; set; }
    public string Purpose { get; set; }
    public StatusTypeEnum Status { get; set; } = StatusTypeEnum.Pending;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Family
    public int FamilyId { get; set; }
    public Family Family { get; set; }

    // Relación con Contributions
    public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

    // Constructor sin parámetros requerido por EF Core
    public SavingsBag() { }

    // Constructores con parámetros
    public SavingsBag(string name, int familyId, decimal idealAmount)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name es obligatorio.");
        FamilyId = familyId;
        if (idealAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(idealAmount), "IdealAmount debe ser mayor que cero.");
        IdealAmount = idealAmount;
    }
}