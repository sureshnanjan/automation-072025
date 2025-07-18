namespace Models
{
    /// <summary>
    /// Represents a user with an integer value.
    /// </summary>
    public class User
    {
        private int v;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the specified integer value.
        /// </summary>
        /// <param name="v">An integer value representing user-specific data.</param>
        public User(int v)
        {
            this.v = v;
        }
    }
}
