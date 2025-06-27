namespace Assignment1.Models.DTOs.Role
{
    public class RoleResponseDTO
    {
        public int RoleID { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }
    }
}
