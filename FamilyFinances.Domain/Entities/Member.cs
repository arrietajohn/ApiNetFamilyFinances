namespace FamilyFinances.Domain.Entities;

public class Member
{
    public int MemberId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Position { get; set; }
    public string Occupation { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Relación con Family
    public int FamilyId { get; set; }
    public Family Family { get; set; }

    // Relación opcional con User
    public string UserName { get; set; }
    public User User { get; set; }

    // Relación con Incomes y Expenses
    public ICollection<Income> Incomes { get; set; } = new List<Income>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    // Constructores
    public Member() { }

    public Member(string firstName, string lastName, int familyId)
    {
        FirstName = firstName;
        LastName = lastName;
        FamilyId = familyId;
    }

    public Member(int memberId, string firstName, string lastName, int familyId)
    {
        MemberId = memberId;
        FirstName = firstName;
        LastName = lastName;
        FamilyId = familyId;
    }
}
