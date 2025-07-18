namespace Models
{
    /// <summary>
    /// Represents a user with an integer value identifier.
    /// </summary>
    /// <remarks>
    /// This class encapsulates a simple user object that stores
    /// an integer value. The value is assigned during construction.
    /// </remarks>
    public class User
    {
        private int v;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="v">The integer value to assign to the user.</param>
        public User(int v)
        {
            this.v = v;
        }
    }
}

