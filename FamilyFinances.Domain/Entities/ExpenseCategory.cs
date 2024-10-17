using System;
using System.Collections.Generic;

namespace FamilyFinances.Domain.Entities
{
    public class ExpenseCategory
    {
        public int ExpenseCategoryId { get; set; }  // Clave primaria
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; } = "Category.png";
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Relaciones
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

        // Constructor sin parámetros requerido por EF Core
        public ExpenseCategory() { }

        // Constructores con parámetros
        public ExpenseCategory(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name es obligatorio.");
            Description = description ?? throw new ArgumentNullException(nameof(description), "Description es obligatoria.");
        }

        public ExpenseCategory(string name, string description, string icon)
            : this(name, description)
        {
            Icon = icon;
        }
    }
}
