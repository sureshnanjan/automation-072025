namespace Petstore.Models
{
    /// <summary>
    /// Represents a user in the Petstore system.
    /// </summary>
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// User status code. e.g., 1 = active, 0 = inactive.
        /// </summary>
        public int UserStatus { get; set; }
    }
}
