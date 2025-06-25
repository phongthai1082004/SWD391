using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("Tests")]
    public class Test : BaseEntity
    {
        [Key]
        public int TestID { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Frequency { get; set; }
        // Relationships
        public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
    }
}
