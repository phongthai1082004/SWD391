using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("LeaveRequest")]
    public class LeaveRequest : BaseEntity
    {
        [Key]
        public int LeaveID { get; set; }

        public int UserID { get; set; }

        public int ApproverID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Required]
        public required string Status { get; set; }

        //Relationships
        [ForeignKey(nameof(UserID))]
        [InverseProperty(nameof(Models.User.LeaveRequests))]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(ApproverID))]
        [InverseProperty(nameof(Models.User.ApprovedRequests))]
        public User Approver { get; set; } = null!;

    }
}
