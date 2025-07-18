namespace Petstore.Models
{
    /// <summary>
    /// Represents a category for a pet.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }
    }
}
