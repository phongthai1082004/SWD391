using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models.DTOs.User
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "RoleID is required.")]
        public int RoleID { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }
    }
}
