using Assignment1.Models.DTOs.Role;
using Assignment1.Repository;

namespace Assignment1.Services
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<RoleResponseDTO> _roleRepository;
        public RoleService(IBaseRepository<RoleResponseDTO> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<RoleResponseDTO?> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
