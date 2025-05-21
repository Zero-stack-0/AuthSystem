namespace AuthSystem.Model
{
    public class Users
    {
        public Users()
        {

        }

        public Users(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreateDate = DateTime.UtcNow;
            Password = password;
            UpdatedDate = null;
            IsActive = true;
        }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}