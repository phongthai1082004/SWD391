using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("Document")]
    public class Document : BaseEntity
    {
        [Key]
        public int DocumentID { get; set; }
        public int UserID { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Verified { get; set; }

        //Relationships
        public User User { get; set; } = null!;
    }
}
