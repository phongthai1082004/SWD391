using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("WorkSchedule")]
    public class WorkSchedule : BaseEntity
    {
        [Key]
        public int ScheduleID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public required string Shift { get; set; }

        // Relationships
        public User User { get; set; } = null!;
    }
}
