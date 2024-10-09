namespace FamilyFinances.Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Relación con Users
    public ICollection<User> Users { get; set; } = new List<User>();

    // Constructores
    public Role() { }

    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Role(int roleId, string name, string description)
    {
        RoleId = roleId;
        Name = name;
        Description = description;
    }
}

