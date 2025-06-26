namespace Assignment1.Models.DTOs.User
{
    public class UserUpdateDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleID { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
    }
}
