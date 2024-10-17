using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IRoleRepository
{
    Task<Role> GetRoleById(int roleId);
    Task<IEnumerable<Role>> GetAllRoles();
    Task AddRole(Role role);
    Task UpdateRole(Role role);
    Task DeleteRole(int roleId);
}
