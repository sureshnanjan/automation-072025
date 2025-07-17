using System;

namespace Models
{
    /// <summary>
    /// Represents an order placed by the user.
    /// </summary>
    public class Order
    {
        public long? Id { get; set; }

        public long? PetId { get; set; }

        public int? Quantity { get; set; }

        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Order status (e.g., placed, approved, delivered).
        /// </summary>
        public string Status { get; set; }

        public bool? Complete { get; set; }
    }
}
