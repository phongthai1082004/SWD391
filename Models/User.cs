using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        // Foreign Key
        public int RoleID { get; set; }
        public string? Status { get; set; } // active, locked
        public string? Description { get; set; }

        // Relationships
        public Role Role { get; set; } = null!;
        public EmployeeProfile? EmployeeProfile { get; set; } = null!;
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<FormTemplate> FormTemplates { get; set; } = new List<FormTemplate>();
        public ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
        public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

        // Navigation tới các đơn nghỉ phép do User tạo
        [InverseProperty(nameof(LeaveRequest.User))]
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        // Navigation tới các đơn do User phê duyệt
        [InverseProperty(nameof(LeaveRequest.Approver))]
        public ICollection<LeaveRequest> ApprovedRequests { get; set; } = new List<LeaveRequest>();

    }
}
