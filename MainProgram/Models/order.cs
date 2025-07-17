using System;

namespace Models
{
    /// <summary>
    /// Represents a purchase order placed in the pet store system.
    /// </summary>
    internal class Order
    {
        /// <summary>
        /// Unique identifier for the order.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// The ID of the pet being ordered.
        /// </summary>
        public long? PetId { get; set; }

        /// <summary>
        /// Quantity of the pet items ordered.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Expected shipping date and time for the order.
        /// </summary>
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Current status of the order (e.g., "placed", "approved", "delivered").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Indicates whether the order is complete.
        /// </summary>
        public bool? Complete { get; set; }
    }
}