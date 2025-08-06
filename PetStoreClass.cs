// --------------------------------------------------------------------------
// Copyright (c) 2025 Sehwag Vijay
// All rights reserved.
//
// This code is part of the Swagger Petstore model structure in C#
// and may not be used, copied, modified, or distributed without
// written permission.
//
// Author: Sehwag Vijay
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SwaggerPetstore.Models
{
    /// <summary>
    /// Represents a standard API response structure.
    /// </summary>
    public class ApiResponse
    {
        public int Code { get; set; } // Response status code
        public string Type { get; set; } // Type of response (e.g., "error", "success")
        public string Message { get; set; } // Descriptive message
    }

    /// <summary>
    /// Represents the category of a pet (e.g., Dog, Cat).
    /// </summary>
    public class Category
    {
        public long Id { get; set; } // Unique identifier
        public string Name { get; set; } // Name of the category
    }

    /// <summary>
    /// Represents a tag used to label pets (e.g., "Friendly", "Small").
    /// </summary>
    public class Tag
    {
        public long Id { get; set; } // Unique identifier
        public string Name { get; set; } // Tag name
    }

    /// <summary>
    /// Enum representing possible statuses of a pet in the store.
    /// </summary>
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
        public long Id { get; set; } // Unique pet ID
        public Category Category { get; set; } // Category object the pet belongs to
        public string Name { get; set; } // Name of the pet (Required)
        public List<string> PhotoUrls { get; set; } // URLs of pet photos (Required)
        public List<Tag> Tags { get; set; } // List of tags associated with the pet
        public string Status { get; set; } // Current status in the store (could use PetStatus enum)
    }

    /// <summary>
    /// Enum representing status of an order.
    /// </summary>
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
        public long Id { get; set; } // Order ID
        public long PetId { get; set; } // ID of the pet being ordered
        public int Quantity { get; set; } // Number of items ordered
        public DateTime ShipDate { get; set; } // Date the order is scheduled to ship
        public OrderStatus Status { get; set; } // Current status of the order
        public bool Complete { get; set; } // Whether the order is complete
    }

    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        public long Id { get; set; } // User ID
        public string Username { get; set; } // Unique username
        public string FirstName { get; set; } // First name
        public string LastName { get; set; } // Last name
        public string Email { get; set; } // Email address
        public string Password { get; set; } // Password (stored securely in real apps)
        public string Phone { get; set; } // Phone number
        public int UserStatus { get; set; } // User status code (e.g., 1 = active, 0 = inactive)
    }
}
