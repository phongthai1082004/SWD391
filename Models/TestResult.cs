namespace Assignment1.Models
{
    public class TestResult : BaseEntity
    {
        public int ResultID { get; set; }
        public int UserID { get; set; }
        public int TestID { get; set; }
        public float Score { get; set; }
        public DateTime DateTaken { get; set; }
        // Relationships
        public User User { get; set; }
        public Test Test { get; set; }
    }
}
