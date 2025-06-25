namespace Assignment1.Models
{
    public class User : BaseEntity
    {
        public User(int UserId, string name, string email, string password, int roleId, string status)
        {
            UserID = UserId;
            Name = name;
            Email = email;
            Password = password;
            RoleID = roleId;
            Status = status;
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Status { get; set; } // active, locked
        public string Description { get; set; }
        public List<Document> Documents { get; set; }
        public Role Role { get; set; }


    }
}
