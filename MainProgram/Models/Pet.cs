using System;
using System.Collections.Generic;

namespace Models
{
<<<<<<< HEAD
    public class Pet
    {
        public int MyProperty { get; set; }
=======
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
>>>>>>> 33ca87d (Added pet object logic and all the models for the petstore and with the documentation)
    }
}
