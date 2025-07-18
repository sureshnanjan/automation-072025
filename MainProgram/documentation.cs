/**
* PetStoreModels.cs
*
* © 2025 VARUN KUMAR REDDY D. All rights reserved.
* This file contains data models used for working with 
* the PetStore REST API. These models help convert JSON 
* to C# objects and vice versa for easy API handling.
* 
* Author: VARUN KUMAR REDDY D
* License: Strictly for academic learning and personal project use only.
*/

using System;
using System.Collections.Generic;

namespace PetStoreModels
{
    /// <summary>
    /// Represents a generic response structure from the PetStore API.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>Status code of the API response (e.g., 200 OK, 404 Not Found).</summary>
        public int code { get; set; }

        /// <summary>Type of the response like "success" or "error".</summary>
        public string type { get; set; }

        /// <summary>Message content from the response for logging or display.</summary>
        public string message { get; set; }
    }

    /// <summary>
    /// Represents a category that pets can belong to (e.g., Dogs, Cats).
    /// </summary>
    public class Category
    {
        /// <summary>Unique ID for the category.</summary>
        public long id { get; set; }

        /// <summary>Name or label of the category.</summary>
        public string name { get; set; }
    }

    /// <summary>
    /// Describes additional characteristics of a pet like "friendly", "trained".
    /// </summary>
    public class Tag
    {
        /// <summary>Unique ID assigned to the tag.</summary>
        public long id { get; set; }

        /// <summary>Descriptive keyword associated with a pet.</summary>
        public string name { get; set; }
    }

    /// <summary>
    /// A class representing the main Pet entity in the PetStore.
    /// </summary>
    public class Pet
    {
        /// <summary>Unique pet identifier.</summary>
        public long id { get; set; }

        /// <summary>The category the pet is grouped under.</summary>
        public Category category { get; set; }

        /// <summary>Name of the pet.</summary>
        public string name { get; set; }

        /// <summary>Collection of image URLs related to the pet.</summary>
        public List<string> photoUrls { get; set; }

        /// <summary>Tags describing the pet.</summary>
        public List<Tag> tags { get; set; }

        /// <summary>Availability status of the pet (e.g., available, sold).</summary>
        public string status { get; set; }
    }

    /// <summary>
    /// Represents a purchase order made for a pet.
    /// </summary>
    public class Order
    {
        /// <summary>Order ID.</summary>
        public long id { get; set; }

        /// <summary>Pet ID included in the order.</summary>
        public long petId { get; set; }

        /// <summary>Quantity of pets ordered.</summary>
        public int quantity { get; set; }

        /// <summary>Expected shipping date for the order.</summary>
        public string shipDate { get; set; }

        /// <summary>Status of the order (e.g., placed, approved).</summary>
        public string status { get; set; }

        /// <summary>Marks whether the order is completed or not.</summary>
        public bool complete { get; set; }
    }

    /// <summary>
    /// A model class representing a user in the PetStore.
    /// </summary>
    public class User
    {
        /// <summary>User ID for tracking and identification.</summary>
        public long id { get; set; }

        /// <summary>Login username.</summary>
        public string username { get; set; }

        /// <summary>User’s first name.</summary>
        public string firstName { get; set; }

        /// <summary>User’s last name.</summary>
        public string lastName { get; set; }

        /// <summary>Email address for the user.</summary>
        public string email { get; set; }

        /// <summary>User's password (used for login/authentication).</summary>
        public string password { get; set; }

        /// <summary>Phone number linked to the account.</summary>
        public string phone { get; set; }

        /// <summary>Status code to represent user’s activity or state.</summary>
        public int userStatus { get; set; }
    }
}
