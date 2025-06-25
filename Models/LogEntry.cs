using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("LogEntry")]
    public class LogEntry : BaseEntity
    {
        [Key]
        public int LogID { get; set; }
        public int UserID { get; set; }

        [Required]
        public required string Action { get; set; }
        [Required]
        public required string ModifiedFields { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Editor { get; set; }

        //Relationships
        public User User { get; set; } = null!;

    }
}
