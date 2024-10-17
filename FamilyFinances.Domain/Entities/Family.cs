using System;
using System.Collections.Generic;

namespace FamilyFinances.Domain.Entities
{
    public class Family
    {
        public int FamilyId { get; set; }  // Clave primaria
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Relaciones
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<SavingsBag> SavingsBags { get; set; } = new List<SavingsBag>();

        // Constructor sin parámetros requerido por EF Core
        public Family() { }

        // Constructor con parámetros
        public Family(string name, string address, string phoneNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name es obligatorio.");
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
