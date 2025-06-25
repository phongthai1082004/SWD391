using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("TestResults")]
    public class TestResult : BaseEntity
    {
        [Key]
        public int ResultID { get; set; }
        public int UserID { get; set; }
        public int TestID { get; set; }
        public float Score { get; set; }
        public DateTime DateTaken { get; set; }

        // Relationships

        public User User { get; set; } = null!;
        public Test Test { get; set; } = null!;

    }
}
