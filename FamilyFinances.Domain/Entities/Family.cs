namespace FamilyFinances.Domain.Entities;

public class Family
{
    public int FamilyId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true;

    // Relación con Members y SavingsBags
    public ICollection<Member> Members { get; set; } = new List<Member>();
    public ICollection<SavingsBag> SavingsBags { get; set; } = new List<SavingsBag>();

    // Constructores
    public Family() { }

    public Family(string name, string address, string phoneNumber)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        IsActive = true;
    }

    public Family(int familyId, string name, string address, string phoneNumber, bool isActive)
    {
        FamilyId = familyId;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }
}

