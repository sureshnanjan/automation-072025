/**
* PetStoreModels.cs
*
* © 2025 TEJA. All rights reserved.
* This file defines data model classes used to interact with 
* the PetStore RESTful API. These models help serialize and 
* deserialize JSON data during API communication.
* 
* Author: TEJA
* License: For academic and non-commercial purposes only.
*/

using System;
using System.Collections.Generic;

namespace PetStoreModels
{
	/// <summary>
	/// Represents a standard response returned by the PetStore API.
	/// </summary>
	public class ApiResponse
	{
		/// <summary>HTTP status code (e.g., 200 for OK, 404 for Not Found).</summary>
		public int code { get; set; }

		/// <summary>Describes the type of response (e.g., "success", "error").</summary>
		public string type { get; set; }

		/// <summary>A message provided in the response, often used for feedback or error description.</summary>
		public string message { get; set; }
	}

	/// <summary>
	/// Represents a category to which pets may belong (e.g., "Dogs", "Birds").
	/// </summary>
	public class Category
	{
		/// <summary>Unique identifier for the category.</summary>
		public long id { get; set; }

		/// <summary>The name of the category.</summary>
		public string name { get; set; }
	}

	/// <summary>
	/// Describes a tag that provides additional information about a pet (e.g., "friendly", "adopted").
	/// </summary>
	public class Tag
	{
		/// <summary>Unique identifier for the tag.</summary>
		public long id { get; set; }

		/// <summary>The label or keyword of the tag.</summary>
		public string name { get; set; }
	}

	/// <summary>
	/// Represents a pet listed in the PetStore.
	/// </summary>
	public class Pet
	{
		/// <summary>Unique identifier for the pet.</summary>
		public long id { get; set; }

		/// <summary>The category the pet is classified under.</summary>
		public Category category { get; set; }

		/// <summary>The pet's name.</summary>
		public string name { get; set; }

		/// <summary>A list of URLs pointing to images of the pet.</summary>
		public List<string> photoUrls { get; set; }

		/// <summary>Tags associated with the pet for classification.</summary>
		public List<Tag> tags { get; set; }

		/// <summary>Current availability status of the pet (e.g., available, pending, sold).</summary>
		public string status { get; set; }
	}

	/// <summary>
	/// Represents an order placed for purchasing a pet.
	/// </summary>
	public class Order
	{
		/// <summary>Unique identifier for the order.</summary>
		public long id { get; set; }

		/// <summary>Identifier of the pet being ordered.</summary>
		public long petId { get; set; }

		/// <summary>Number of pets ordered.</summary>
		public int quantity { get; set; }

		/// <summary>Expected shipping date (in ISO 8601 format).</summary>
		public string shipDate { get; set; }

		/// <summary>Current status of the order (e.g., placed, approved, delivered).</summary>
		public string status { get; set; }

		/// <summary>Indicates whether the order has been completed.</summary>
		public bool complete { get; set; }
	}

	/// <summary>
	/// Represents a user in the PetStore system.
	/// </summary>
	public class User
	{
		/// <summary>Unique identifier for the user.</summary>
		public long id { get; set; }

		/// <summary>Username used for login purposes.</summary>
		public string username { get; set; }

		/// <summary>First name of the user.</summary>
		public string firstName { get; set; }

		/// <summary>Last name of the user.</summary>
		public string lastName { get; set; }

		/// <summary>Email address associated with the user.</summary>
		public string email { get; set; }

		/// <summary>Password for the user account (used for authentication).</summary>
		public string password { get; set; }

		/// <summary>Phone number linked to the user.</summary>
		public string phone { get; set; }

		/// <summary>Status code representing the user's account state.</summary>
		public int userStatus { get; set; }
	}
}
