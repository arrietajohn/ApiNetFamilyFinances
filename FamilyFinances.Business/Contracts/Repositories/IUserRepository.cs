using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;

public interface IUserRepository
{
    User GetUserById(string userName);
    User GetUserByEmail(string email);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(string userName);
    bool ExistsByUserName(string userName);
    bool ExistsByEmail(string email);
}
