using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
