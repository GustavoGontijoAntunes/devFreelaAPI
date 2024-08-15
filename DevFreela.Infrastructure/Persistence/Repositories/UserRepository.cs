using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task AddUserSkills(List<UserSkill> usersSkills)
        {
            await _context.UserSkills.AddRangeAsync(usersSkills);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetDetailsById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .Include(u => u.OwnedProjects)
                .Include(u => u.FreelanceProjects)
                .Include(u => u.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return user;
        }
    }
}