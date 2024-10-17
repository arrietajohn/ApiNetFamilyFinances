namespace FamilyFinances.Domain.Entities;

public class Member
{
    public int MemberId { get; set; }  // Clave primaria
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Position { get; set; }
    public string Occupation { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Clave foránea hacia User
    public string UserId { get; set; }  // Clave foránea a User.UserName
    public User User { get; set; }

    // Relación con Family
    public int FamilyId { get; set; }
    public Family Family { get; set; }

    // Relaciones con Incomes, Expenses y Contributions
    public ICollection<Income> Incomes { get; set; } = new List<Income>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

    // Constructor sin parámetros requerido por EF Core
    public Member() { }

    // Constructor con parámetros
    public Member(string userId, int familyId, string firstName, string lastName)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId), "UserId es obligatorio.");
        FamilyId = familyId;
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName), "FirstName es obligatorio.");
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName), "LastName es obligatorio.");
    }
}
