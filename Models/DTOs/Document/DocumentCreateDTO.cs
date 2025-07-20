using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models.DTOs.Document
{
    public class DocumentCreateDTO
    {
        [Required(ErrorMessage = "DocumentID is required.")]
        public int DocumentID { get; set; }

        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "FilePath is required.")]
        [StringLength(255, ErrorMessage = "FilePath cannot exceed 255 characters.")]
        public string FilePath { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "UploadDate is required.")]
        public DateTime UploadDate { get; set; }

        public bool Verified { get; set; }
    }
}
