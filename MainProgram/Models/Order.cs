using System;

namespace Petstore.Models
{
    /// <summary>
    /// Represents a pet order in the Petstore system.
    /// </summary>
    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the pet ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the ship date of the order.
        /// </summary>
        public DateTime ShipDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the order (placed, approved, delivered).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the order is complete.
        /// </summary>
        public bool Complete { get; set; }
    }
}
