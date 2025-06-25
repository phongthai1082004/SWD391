namespace Assignment1.Models
{
    public class EmployeeProfile : BaseEntity
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
    }
}
