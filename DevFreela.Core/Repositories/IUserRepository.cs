using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task AddUserSkills(List<UserSkill> usersSkills);
        Task<User?> GetDetailsById(int id);
    }
}