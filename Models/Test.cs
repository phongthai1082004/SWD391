namespace Assignment1.Models
{
    public class Test : BaseEntity
    {
        public int TestID { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Frequency { get; set; }
        // Relationships
        public List<TestResult> TestResults { get; set; }
    }
}
