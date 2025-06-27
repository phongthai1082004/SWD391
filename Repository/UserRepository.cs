using Assignment1.Data;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<List<User>> GetUsersWithRolesAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }
    }
}
