namespace Assignment1.Models
{
    public class LogEntry : BaseEntity
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Action { get; set; }
        public string ModifiedFields { get; set; }
        public DateTime Timestamp { get; set; }
        public string Editor { get; set; }
    }
}
