namespace Models
{
    /// <summary>
    /// Represents a user of the PetStore system.
    /// </summary>
    public class User
    {
<<<<<<< HEAD
        private int v;

        public User(int v)
        {
            this.v = v;
        }
=======
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// This is optional and may be null when creating a new user.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets the username used to log in.
        /// This is a unique name that identifies the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// Used for communication and notifications.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user's account.
        /// This should be securely stored and never logged.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// Can be used for contact or verification purposes.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the status of the user account.
        /// Example values: 0 (inactive), 1 (active), etc.
        /// </summary>
        public int? UserStatus { get; set; }
>>>>>>> 33ca87d (Added pet object logic and all the models for the petstore and with the documentation)
    }
}
