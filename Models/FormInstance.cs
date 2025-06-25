using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class FormInstance : BaseEntity
    {
        public int InstanceID { get; set; }
        public int FormTemplateID { get; set; }
        public int ProfileID { get; set; }
        [NotMapped]
        public Dictionary<string, string> FilledData { get; set; } = new();

        // Relationships 
        public FormTemplate FormTemplate { get; set; } = null!;
        public EmployeeProfile EmployeeProfile { get; set; } = null!;
    }
}
