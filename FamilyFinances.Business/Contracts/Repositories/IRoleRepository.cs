using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IRoleRepository
{
    Role GetRoleById(int roleId);
    IEnumerable<Role> GetAllRoles();
    void AddRole(Role role);
    void UpdateRole(Role role);
    void DeleteRole(int roleId);
}
