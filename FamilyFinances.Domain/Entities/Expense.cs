using System;
using System.Collections.Generic;

namespace FamilyFinances.Domain.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Relación con Member
        public int MemberId { get; set; }
        public Member Member { get; set; }

        // Relación con ExpenseCategory
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        // Relación con Contributions
        public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

        // Constructor sin parámetros requerido por EF Core
        public Expense() { }

        // Constructores con parámetros
        public Expense(string name, decimal amount, int memberId, int expenseCategoryId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name es obligatorio.");
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount debe ser mayor que cero.");
            Amount = amount;
            MemberId = memberId;
            ExpenseCategoryId = expenseCategoryId;
        }
    }
}
