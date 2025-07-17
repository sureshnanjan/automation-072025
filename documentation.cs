// -----------------------------------------------------------------------------
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
            var request = new RestRequest("pet/findByStatus", Method.Get);
            request.AddParameter("status", status);

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"API Error: {response.StatusCode} - {response.Content}");
            }

            return JsonConvert.DeserializeObject<List<Pet>>(response.Content);
        }
    }

    /// <summary>
    /// Program entry point to demonstrate API usage.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new PetStoreClient();
                var pets = client.GetPetsByStatus("available");

                Console.WriteLine("Available Pets from Swagger Petstore:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
