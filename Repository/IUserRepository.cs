using Assignment1.Models;

namespace Assignment1.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetUsersWithRolesAsync();
    }
}
