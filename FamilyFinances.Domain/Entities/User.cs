using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinances.Domain.Entities
{
    public class User
    {
        public string UserName { get; set; }  // Clave primaria
        public string Password { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Clave foránea hacia Role
        [Column("RolId")]
        public int RolId { get; set; }
        public Role Role { get; set; }

        // Relación opcional con Member
        public Member Member { get; set; }

        // Constructor sin parámetros requerido por EF Core
        public User() { }

        // Constructores con parámetros
        public User(string userName, string password, string email, int rolId)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName es obligatorio.");
            Password = password ?? throw new ArgumentNullException(nameof(password), "Password es obligatorio.");
            Email = email ?? throw new ArgumentNullException(nameof(email), "Email es obligatorio.");
            RolId = rolId;
        }
    }
}
