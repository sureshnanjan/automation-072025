namespace Petstore.Models
{
    /// <summary>
    /// Represents a tag that can be assigned to a pet.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the tag ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        public string Name { get; set; }
    }
}

