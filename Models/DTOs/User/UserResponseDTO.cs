namespace Assignment1.Models.DTOs.User
{
    public class UserResponseDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
