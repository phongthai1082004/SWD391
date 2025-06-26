using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        // Foreign Key
        public int RoleID { get; set; }

        public string? Status { get; set; } // active, locked

        public string? Description { get; set; }

        // Relationships
        public Role? Role { get; set; }

        public EmployeeProfile? EmployeeProfile { get; set; }

        public ICollection<Document>? Documents { get; set; } = new List<Document>();

        public ICollection<FormTemplate>? FormTemplates { get; set; } = new List<FormTemplate>();

        public ICollection<LogEntry>? LogEntries { get; set; } = new List<LogEntry>();

        public ICollection<WorkSchedule>? WorkSchedules { get; set; } = new List<WorkSchedule>();

        public ICollection<TestResult>? TestResults { get; set; } = new List<TestResult>();

        [InverseProperty(nameof(LeaveRequest.User))]
        public ICollection<LeaveRequest>? LeaveRequests { get; set; } = new List<LeaveRequest>();

        [InverseProperty(nameof(LeaveRequest.Approver))]
        public ICollection<LeaveRequest>? ApprovedRequests { get; set; } = new List<LeaveRequest>();
    }
}
