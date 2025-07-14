/**
* PetStoreModels.cs
*
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* This file defines all model classes for the PetStore REST API.
* These models are used to serialize and deserialize JSON data
* when interacting with PetStore endpoints.
* 
* Author: SOWMYA SRIDHAR
* License: For educational and non-commercial use only.
*/

using System;
using System.Collections.Generic;

namespace PetStoreModels
{
    /// <summary>
    /// Represents the standard response from the API.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>HTTP status code (e.g., 200, 404).</summary>
        public int code { get; set; }

        /// <summary>Response type string (e.g., "error", "success").</summary>
        public string type { get; set; }

        /// <summary>Message included in the API response.</summary>
        public string message { get; set; }
    }

    /// <summary>
    /// Represents a category to which a pet belongs (e.g., Dogs, Cats).
    /// </summary>
    public class Category
    {
        /// <summary>Unique category ID.</summary>
        public long id { get; set; }

        /// <summary>Name of the category.</summary>
        public string name { get; set; }
    }

    /// <summary>
    /// Represents a tag associated with a pet (e.g., "friendly", "playful").
    /// </summary>
    public class Tag
    {
        /// <summary>Unique tag ID.</summary>
        public long id { get; set; }

        /// <summary>Name or keyword of the tag.</summary>
        public string name { get; set; }
    }

    /// <summary>
    /// Represents a pet in the PetStore.
    /// </summary>
    public class Pet
    {
        /// <summary>Unique ID of the pet.</summary>
        public long id { get; set; }

        /// <summary>The category this pet belongs to.</summary>
        public Category category { get; set; }

        /// <summary>Name of the pet (e.g., "doggie").</summary>
        public string name { get; set; }

        /// <summary>List of photo URLs showing this pet.</summary>
        public List<string> photoUrls { get; set; }

        /// <summary>Tags related to the pet.</summary>
        public List<Tag> tags { get; set; }

        /// <summary>Status of the pet in the store: available, pending, or sold.</summary>
        public string status { get; set; }
    }

    /// <summary>
    /// Represents a purchase order placed for a pet.
    /// </summary>
    public class Order
    {
        /// <summary>Unique order ID.</summary>
        public long id { get; set; }

        /// <summary>ID of the pet being ordered.</summary>
        public long petId { get; set; }

        /// <summary>Quantity of pets being ordered.</summary>
        public int quantity { get; set; }

        /// <summary>Shipping date in ISO 8601 format.</summary>
        public string shipDate { get; set; }

        /// <summary>Order status: placed, approved, or delivered.</summary>
        public string status { get; set; }

        /// <summary>Flag indicating whether the order is complete.</summary>
        public bool complete { get; set; }
    }

    /// <summary>
    /// Represents a user account in the PetStore system.
    /// </summary>
    public class User
    {
        /// <summary>Unique ID of the user.</summary>
        public long id { get; set; }

        /// <summary>Username used for login.</summary>
        public string username { get; set; }

        /// <summary>User's first name.</summary>
        public string firstName { get; set; }

        /// <summary>User's last name.</summary>
        public string lastName { get; set; }

        /// <summary>Email address of the user.</summary>
        public string email { get; set; }

        /// <summary>Password used for authentication.</summary>
        public string password { get; set; }

        /// <summary>Phone number of the user.</summary>
        public string phone { get; set; }

        /// <summary>Status code representing user's current status.</summary>
        public int userStatus { get; set; }
    }
}
