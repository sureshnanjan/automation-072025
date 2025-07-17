<<<<<<< HEAD
﻿// -----------------------------------------------------------------------------
// Copyright © 2025 Gayathri
// All rights reserved.
//
// This code is a part of PetStoreClientApp.
// Created as a learning project during early career development.
//
// You are free to use, modify, and share this code for educational and 
// non-commercial purposes. For commercial use or redistribution, please 
// contact the author.
//
// Author: Gayathri
// Email : gayathri.thalapathi@ascendion.com
// -----------------------------------------------------------------------------

using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

=======
﻿// Namespace declaration
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
namespace PetStoreClientApp
{
    /// <summary>
    /// Represents a single pet as defined by the Swagger Petstore API.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Unique identifier for the pet.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the pet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current status of the pet (available, pending, or sold).
        /// </summary>
        public string Status { get; set; }
    }

    /// <summary>
    /// Client for interacting with Swagger Petstore API.
    /// </summary>
    public class PetStoreClient
    {
        // Internal RestSharp client for API communication
        private readonly RestClient _client;

        /// <summary>
        /// Initializes the client with the base URL of the Petstore API.
        /// </summary>
        public PetStoreClient()
        {
<<<<<<< HEAD
=======
            // Set the base URL of the Swagger Petstore API
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
            _client = new RestClient("https://petstore.swagger.io/v2");
        }

        /// <summary>
        /// Retrieves a list of pets filtered by their status.
        /// </summary>
        /// <param name="status">Pet status: available, pending, or sold</param>
        /// <returns>List of Pet objects</returns>
        /// <exception cref="Exception">Thrown when API call fails</exception>
        public List<Pet> GetPetsByStatus(string status)
        {
<<<<<<< HEAD
            var request = new RestRequest("pet/findByStatus", Method.Get);
            request.AddParameter("status", status);

            var response = _client.Execute(request);

=======
            // Create a GET request to the findByStatus endpoint
            var request = new RestRequest("pet/findByStatus", Method.Get);

            // Add 'status' query parameter to the request
            request.AddParameter("status", status);

            // Execute the request and capture the response
            var response = _client.Execute(request);

            // Check if the request was successful; if not, throw an error
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
            if (!response.IsSuccessful)
            {
                throw new Exception($"API Error: {response.StatusCode} - {response.Content}");
            }

<<<<<<< HEAD
=======
            // Deserialize the JSON response into a list of Pet objects
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
            return JsonConvert.DeserializeObject<List<Pet>>(response.Content);
        }
    }

    /// <summary>
    /// Program entry point to demonstrate API usage.
    /// </summary>
    class Program
    {
<<<<<<< HEAD
=======
        /// <summary>
        /// Main method that runs the client and displays available pets.
        /// </summary>
        /// <param name="args">Command-line arguments (not used)</param>
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
        static void Main(string[] args)
        {
            try
            {
<<<<<<< HEAD
                var client = new PetStoreClient();
                var pets = client.GetPetsByStatus("available");

=======
                // Create a new instance of the PetStoreClient
                var client = new PetStoreClient();

                // Fetch available pets from the API
                var pets = client.GetPetsByStatus("available");

                // Display the retrieved pets
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
                Console.WriteLine("Available Pets from Swagger Petstore:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
                }
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                Console.WriteLine($"Error: {ex.Message}");
=======
                // Log any errors encountered during execution
                Console.WriteLine($" Error: {ex.Message}");
>>>>>>> c8b846021937c37a471ad8136f48ad3257eed170
            }
        }
    }
}
