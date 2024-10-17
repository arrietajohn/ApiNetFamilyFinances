using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyFinances.Domain.Entities
{
    public class Role
    {
        [Column("RolId")]
        public int RoleId { get; set; }  // Clave primaria

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Relación con Users
        public ICollection<User> Users { get; set; } = new List<User>();

        // Constructor sin parámetros requerido por EF Core
        public Role() { }

        // Constructores con parámetros
        public Role(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "El nombre es obligatorio.");
        }

        public Role(string name, string description)
            : this(name)
        {
            Description = description;
        }
    }
}
