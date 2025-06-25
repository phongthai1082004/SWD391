namespace Assignment1.Models
{
    public class User : BaseEntity
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Status { get; set; } // active, locked
        public string Description { get; set; }

        // Relationships
        public List<Document> Documents { get; set; }
        public Role Role { get; set; }
        public List<LogEntry> LogEntries { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }
        public List<WorkSchedule> WorkSchedules { get; set; }
        public List<TestResult> TestResults { get; set; }
        public EmployeeProfile EmployeeProfile { get; set; }
        public List<FormTemplate> CreatedFormTemplates { get; set; }
    }
}
