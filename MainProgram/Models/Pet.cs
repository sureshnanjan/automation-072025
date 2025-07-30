using System;
using System.Collections.Generic;

namespace Models
{
<<<<<<< HEAD

    /// <summary>
    /// Represents a Pet in the pet store system.
    /// This model is based on the Swagger Petstore API.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Unique identifier for the pet.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// The category this pet belongs to (e.g., dog, cat, bird).
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Name of the pet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of photo URLs that visually represent the pet.
        /// </summary>
        public List<string> PhotoUrls { get; set; } = new List<string>();

        /// <summary>
        /// A list of tags associated with the pet (e.g., friendly, vaccinated).
        /// </summary>
        public List<Tag> Tags { get; set; } = new List<Tag>();

        /// <summary>
        /// Pet status in the store (e.g., "available", "pending", "sold").
        /// </summary>
        public string Status { get; set; }

=======
    /// <summary>
    /// Represents a pet with customizable properties.
    /// </summary>
    /// <remarks>
    /// This class currently contains a single property, but can be expanded
    /// to include more attributes such as name, type, breed, or age.
    /// </remarks>
    public class Pet
    {
        /// <summary>
        /// Gets or sets a value for the pet's property.
        /// </summary>
        /// <value>
        /// An integer representing a property of the pet. This is a placeholder 
        /// and should be replaced or extended with more meaningful properties.
        /// </value>
        public int MyProperty { get; set; }
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795
    }
}

