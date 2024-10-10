using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IFamilyRepository
{
    Family GetFamilyById(int familyId);
    IEnumerable<Family> GetAllFamilies();
    void AddFamily(Family family);
    void UpdateFamily(Family family);
    void DeleteFamily(int familyId);
}
