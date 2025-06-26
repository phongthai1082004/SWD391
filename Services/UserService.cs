using Assignment1.Models;
using Assignment1.Repository;

namespace Assignment1.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBaseRepository<User> repository) : base(repository)
        {
        }
    }
}
