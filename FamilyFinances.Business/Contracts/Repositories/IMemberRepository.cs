using FamilyFinances.Domain.Entities;

namespace FamilyFinances.Business.Contracts.Repositories;
public interface IMemberRepository
{
    Member GetMemberById(int memberId);
    IEnumerable<Member> GetMembersByFamilyId(int familyId);
    void AddMember(Member member);
    void UpdateMember(Member member);
    void DeleteMember(int memberId);
}
