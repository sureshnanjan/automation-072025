using System;

namespace Models
{
    /// <summary>
    /// Represents a Tag that can be associated with a Pet.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Unique identifier of the tag.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Name or label of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string representation of the tag for debugging or display.
        /// </summary>
        /// <returns>A formatted string with tag details.</returns>
        public override string ToString()
        {
            return $"Tag(Id: {Id}, Name: {Name})";
        }
    }
}
