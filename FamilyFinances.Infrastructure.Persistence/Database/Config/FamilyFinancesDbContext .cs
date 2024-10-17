using FamilyFinances.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FamilyFinances.Infrastructure.Persistence.Database.Config;

public class FamilyFinancesDbContext : DbContext
{
    public FamilyFinancesDbContext(DbContextOptions<FamilyFinancesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<IncomeSource> IncomeSources { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<SavingsBag> SavingsBags { get; set; }
    public DbSet<Contribution> Contributions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Role
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.RoleId);




            entity.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(r => r.Description)
                .HasMaxLength(250);
        });

        // Configuración de User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserName);

            entity.Property(u => u.UserName)
                .HasMaxLength(30);

            entity.Property(u => u.Password)
                .IsRequired();

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(70);

            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Member
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(m => m.MemberId);

            entity.Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(70);

            // Resto de las propiedades...

            entity.HasOne(m => m.User)
                .WithOne(u => u.Member)
                .HasForeignKey<Member>(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Family)
                .WithMany(f => f.Members)
                .HasForeignKey(m => m.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de las demás entidades siguiendo el mismo patrón...

        base.OnModelCreating(modelBuilder);
    }
}
