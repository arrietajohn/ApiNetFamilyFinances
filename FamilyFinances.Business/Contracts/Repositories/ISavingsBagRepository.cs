using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface ISavingsBagRepository
{
    SavingsBag GetSavingsBagById(int savingsBagId);
    IEnumerable<SavingsBag> GetSavingsBagsByFamilyId(int familyId);
    void AddSavingsBag(SavingsBag savingsBag);
    void UpdateSavingsBag(SavingsBag savingsBag);
    void DeleteSavingsBag(int savingsBagId);
}
