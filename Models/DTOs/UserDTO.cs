using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleID { get; set; }
        public string Status { get; set; } // active, locked
    }
}
