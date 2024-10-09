namespace FamilyFinances.Domain.Entities;

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string JwtToken { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }

    // Relación con Role
    public int RoleId { get; set; }
    public Role Role { get; set; }

    // Relación opcional con Member
    public Member Member { get; set; }

    // Constructores
    public User() { }

    public User(string userName, string email, int roleId)
    {
        UserName = userName;
        Email = email;
        RoleId = roleId;
        IsActive = true;
    }

    public User(string userName, string email, string password, int roleId)
    {
        UserName = userName;
        Email = email;
        Password = password;
        RoleId = roleId;
        IsActive = true;
    }
}
