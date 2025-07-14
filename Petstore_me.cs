using System;
using System.Collections.Generic;

namespace PetStoreModels
{
    // This class is used to structure API responses with a status code, type, and message.
    public class ApiResponse
    {
        public int code { get; set; }          // HTTP status code (e.g., 200, 404)
        public string type { get; set; }       // Type of response (e.g., "error", "success")
        public string message { get; set; }    // Descriptive message from the API
    }

    // This class represents a category to which a pet belongs (e.g., Dogs, Cats).
    public class Category
    {
        public long id { get; set; }           // Unique category ID
        public string name { get; set; }       // Name of the category
    }

    // This class represents a tag associated with a pet (e.g., "friendly", "playful").
    public class Tag
    {
        public long id { get; set; }           // Unique tag ID
        public string name { get; set; }       // Tag label or keyword
    }

    // This class defines a pet, including its category, name, photo URLs, tags, and availability status.
    public class Pet
    {
        public long id { get; set; }                       // Unique ID of the pet
        public Category category { get; set; }             // Category object to which pet belongs
        public string name { get; set; }                   // Name of the pet (e.g., "doggie")
        public List<string> photoUrls { get; set; }        // List of URLs to pet photos
        public List<Tag> tags { get; set; }                // List of tags describing the pet

        // Pet status in the store: "available", "pending", or "sold"
        public string status { get; set; }
    }

    // This class represents a purchase order for a pet in the store.
    public class Order
    {
        public long id { get; set; }                       // Unique order ID
        public long petId { get; set; }                    // ID of the pet being ordered
        public int quantity { get; set; }                  // Quantity of pets ordered
        public string shipDate { get; set; }               // Date the order will ship (in ISO 8601 format)

        // Status of the order: "placed", "approved", or "delivered"
        public string status { get; set; }

        public bool complete { get; set; }                 // Whether the order is complete
    }

    // This class holds user account information for the pet store application.
    public class User
    {
        public long id { get; set; }                       // Unique user ID
        public string username { get; set; }               // Unique username
        public string firstName { get; set; }              // First name of the user
        public string lastName { get; set; }               // Last name of the user
        public string email { get; set; }                  // Email address
        public string password { get; set; }               // Password
        public string phone { get; set; }                  // Contact phone number
        public int userStatus { get; set; }                // Integer representing user status (e.g., active/inactive)
    }
}