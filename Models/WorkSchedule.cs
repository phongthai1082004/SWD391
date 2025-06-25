namespace Assignment1.Models
{
    public class WorkSchedule : BaseEntity
    {
        public int ScheduleID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
    }
}
