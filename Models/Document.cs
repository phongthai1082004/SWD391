namespace Assignment1.Models
{
    public class Document : BaseEntity
    {
        public int DocumentID { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Verified { get; set; }
        // Relationships
        public User User { get; set; }
    }
}
