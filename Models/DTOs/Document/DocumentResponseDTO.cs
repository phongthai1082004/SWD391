namespace Assignment1.Models.DTOs.Document
{
    public class DocumentResponseDTO
    {
        public int DocumentID { get; set; }
        public int UserID { get; set; }
        public required string Type { get; set; }
        public required string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Verified { get; set; }
    }
}
