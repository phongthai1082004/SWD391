namespace Assignment1.Models
{
    public class Role : BaseEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } // Admin, HR, Applicant, Employee
        public string Description { get; set; }
        // Relationships
        public List<User> Users { get; set; }
    }
}
