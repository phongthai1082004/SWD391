using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models
{
    [Table("FormTemplate")]
    public class FormTemplate : BaseEntity
    {
        [Key]
        public int TemplateID { get; set; }

        public int UserID { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Type { get; set; }
        public List<string>? Fields { get; set; } = null!;
        public int CreatedByUserID { get; set; }

        //Relationships
        public User User { get; set; } = null!;
        public ICollection<FormInstance> FormInstances { get; set; } = new List<FormInstance>();
    }
}
