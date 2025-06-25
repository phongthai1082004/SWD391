namespace Assignment1.Models
{
    public class LeaveRequest : BaseEntity
    {
        public int LeaveID { get; set; }
        public int UserID { get; set; }
        public int ApproverID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
