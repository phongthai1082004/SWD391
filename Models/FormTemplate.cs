namespace Assignment1.Models
{
    public class FormTemplate : BaseEntity
    {
        public int TemplateID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public List<string> Fields { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
