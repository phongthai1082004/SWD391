using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("EmployeeProfile")]
    public class EmployeeProfile : BaseEntity
    {
        [Key]
        public int ProfileID { get; set; }

        public required string Position { get; set; }
        public required string Department { get; set; }
        public DateTime StartDate { get; set; }
        // Relationships
        public User User { get; set; } = null!;
        public ICollection<FormInstance> FormInstances { get; set; } = new List<FormInstance>();

    }
}
