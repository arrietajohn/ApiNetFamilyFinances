using System;
using System.Collections.Generic;

namespace FamilyFinances.Domain.Entities
{
    public class IncomeSource
    {
        public int IncomeSourceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; } = "IncomeSource.png";
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Relaciones
        public ICollection<Income> Incomes { get; set; } = new List<Income>();

        // Constructor sin parámetros requerido por EF Core
        public IncomeSource() { }

        // Constructores con parámetros
        public IncomeSource(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name es obligatorio.");
        }

        public IncomeSource(string name, string description)
            : this(name)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description), "Description es obligatoria.");
        }

        public IncomeSource(string name, string description, string icon)
            : this(name, description)
        {
            Icon = icon;
        }
    }
}
