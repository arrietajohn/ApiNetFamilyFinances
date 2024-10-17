using FamilyFinances.Business.Contracts.Repositories;
using FamilyFinances.Business.Exceptions;
using FamilyFinances.Domain.Entities;
using FamilyFinances.Infrastructure.Persistence.Database.Config;
using Microsoft.EntityFrameworkCore;

namespace FamilyFinances.Infrastructure.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{

    private readonly FamilyFinancesDbContext familyFinancesDbContext;

    public RoleRepository(FamilyFinancesDbContext familyFinancesDbContext)
    {
        this.familyFinancesDbContext = familyFinancesDbContext;
    }
    public async Task AddRole(Role role)
    {
        var roleResult = await (from r in familyFinancesDbContext.Roles
                                where r.Name.Equals(role.Name, StringComparison.OrdinalIgnoreCase)
                                select r).AnyAsync();

        //var roleResult = await familyFinancesDbContext.Roles.AnyAsync(r => r.Name.Equals(role.Name, StringComparison.OrdinalIgnoreCase));
        if (roleResult)
        {
            throw new RoleAlreadyExistsException(role.Name);
        }

        await familyFinancesDbContext.Roles.AddAsync(role);
        await familyFinancesDbContext.SaveChangesAsync();
    }

    public async Task DeleteRole(int roleId)
    {
        var rolResult = await GetRoleById(roleId);
        familyFinancesDbContext.Remove(rolResult);
        await familyFinancesDbContext.SaveChangesAsync();
    }


     public async Task DeleteRole(string roleName)
    {
        var roleResult = GetRoleByName(roleName);
        familyFinancesDbContext.Remove(roleResult);
        await familyFinancesDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await familyFinancesDbContext.Roles
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Role> GetRoleById(int roleId)
    {
        var rol = await familyFinancesDbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        if (rol is null)
        {
            throw new RoleNotFoundException(roleId);
        }
        return rol;

        // otra forma de hacerlo lo mismo pero usando el operador de coalescencia

        //return await familyFinancesDbContext.Roles
        //        .FirstOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase))
        //        ?? throw new RoleNotFoundException(roleName);


    }

    public async Task<Role> GetRoleByName(string roleName)
    {
        return await familyFinancesDbContext.Roles
                .FirstOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase))
                ?? throw new RoleNotFoundException(roleName);

    }


    public async Task UpdateRole(Role role)
    {
        var roleResult = await (from r in familyFinancesDbContext.Roles
                                where r.Name.Equals(role.Name, StringComparison.OrdinalIgnoreCase)
                                select r).AnyAsync();
        if (!roleResult)
        {
            throw new RoleNotFoundException(role.Name);
        }

        familyFinancesDbContext.Update(role);
        await familyFinancesDbContext.SaveChangesAsync();
    }
}
