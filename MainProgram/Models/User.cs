namespace Models
{
    /// <summary>
    /// Represents a user with an associated integer value.
    /// </summary>
    public class User
    {
        /// <summary>
        /// A private integer field associated with the user.
        /// </summary>
        private int v;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the specified integer value.
        /// </summary>
        /// <param name="v">An integer value to initialize the user with.</param>
        public User(int v)
        {
            this.v = v;
        }
    }
}
