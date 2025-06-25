using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public required string RoleName { get; set; }
        [Required]
        public required string Description { get; set; }
        //Relationships
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
