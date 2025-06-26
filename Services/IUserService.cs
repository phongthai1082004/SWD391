using Assignment1.Models.DTOs.User;

namespace Assignment1.Services
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateAsync(UserCreateDTO dto);
        Task<UserResponseDTO?> UpdateAsync(UserUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UserResponseDTO?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();
    }
}
