using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SwaggerPetstore.Models
{
    /// <summary>
    /// Represents a standard API response structure.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Response status code.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Type of response (e.g., "error", "success").
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Descriptive message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Represents the category of a pet (e.g., Dog, Cat).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents a tag used to label pets (e.g., "Friendly", "Small").
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the tag.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Enum representing possible statuses of a pet in the store.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PetStatus
    {
        Available,
        Pending,
        Sold
    }

    /// <summary>
    /// Represents a pet in the store.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Unique pet ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Category object the pet belongs to.
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; set; }

        /// <summary>
        /// Name of the pet (Required).
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// URLs of pet photos (Required).
        /// </summary>
        [JsonPropertyName("photoUrls")]
        public List<string> PhotoUrls { get; set; }

        /// <summary>
        /// List of tags associated with the pet.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Current status in the store.
        /// </summary>
        [JsonPropertyName("status")]
        public PetStatus Status { get; set; }
    }

    /// <summary>
    /// Enum representing status of an order.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Placed,
        Approved,
        Delivered
    }

    /// <summary>
    /// Represents a customer order for a pet.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// ID of the pet being ordered.
        /// </summary>
        [JsonPropertyName("petId")]
        public long PetId { get; set; }

        /// <summary>
        /// Number of items ordered.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Date the order is scheduled to ship.
        /// </summary>
        [JsonPropertyName("shipDate")]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Current status of the order.
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Whether the order is complete.
        /// </summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
    }

    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Unique username.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// First name of the user.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// User's password (should be securely hashed in real apps).
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// User status code (e.g., 1 = active, 0 = inactive).
        /// </summary>
        [JsonPropertyName("userStatus")]
        public int UserStatus { get; set; }
    }
}
