using Assignment1.Models;
using Assignment1.Models.DTOs.User;
using Assignment1.Repository;

namespace Assignment1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IBaseRepository<Role> _roleRepo;

        public UserService(IUserRepository userRepo, IBaseRepository<Role> roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<UserResponseDTO> CreateAsync(UserCreateDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                RoleID = dto.RoleID,
                Status = dto.Status,
                Description = dto.Description
            };

            await _userRepo.AddAsync(user);
            var role = await _roleRepo.GetByIdAsync(user.RoleID);
            return new UserResponseDTO
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                RoleName = role?.RoleName ?? "Unknown"
            };
        }

        public async Task<UserResponseDTO?> UpdateAsync(UserUpdateDTO dto)
        {
            var user = await _userRepo.GetByIdAsync(dto.UserID);
            if (user == null) return null;

            user.Name = dto.Name;
            user.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = dto.Password;
            user.RoleID = dto.RoleID;
            user.Status = dto.Status;
            user.Description = dto.Description;

            await _userRepo.UpdateAsync(user);

            var role = await _roleRepo.GetByIdAsync(user.RoleID);
            return new UserResponseDTO
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                RoleName = role?.RoleName ?? "Unknown"
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepo.DeleteAsync(id);
            return true;
        }

        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return null;

            var role = await _roleRepo.GetByIdAsync(user.RoleID);
            return new UserResponseDTO
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                RoleName = role?.RoleName ?? "Unknown"
            };
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(u => new UserResponseDTO
            {
                UserID = u.UserID,
                Name = u.Name,
                Email = u.Email,
                RoleName = u.Role?.RoleName ?? ""
            });
        }
    }
}
