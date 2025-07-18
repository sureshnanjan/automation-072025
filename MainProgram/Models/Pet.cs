using System.Collections.Generic;

namespace Petstore.Models
{
    /// <summary>
    /// Represents a pet in the Petstore.
    /// </summary>
    public class Pet
    {
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the category of the pet.
        /// </summary>
        public Category Category { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the photo URLs of the pet.
        /// </summary>
        public List<string> PhotoUrls { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the pet.
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the status of the pet (available, pending, sold).
        /// </summary>
        public string Status { get; set; }
    }
}

