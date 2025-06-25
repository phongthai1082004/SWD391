namespace Assignment1.Models
{
    public class FormInstance : BaseEntity
    {
        public int InstanceID { get; set; }
        public int TemplateID { get; set; }
        public int ProfileID { get; set; }
        public Dictionary<string, string> FilledData { get; set; }
    }
}
