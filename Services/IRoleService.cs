using Assignment1.Models.DTOs.Role;

namespace Assignment1.Services
{
    public interface IRoleService
    {
        Task<RoleResponseDTO?> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleResponseDTO>> GetAllRolesAsync();
    }
}
