using System;
using System.Collections.Generic;
using Models;

internal class Program
{
    /// <summary>
    /// Entry point of the application.
    /// Demonstrates creation and usage of Pet and Category objects.
    /// </summary>
    private static void Main(string[] args)
    {
        // Initialize sample categories
        Category[] categories = new Category[]
        {
            new Category { Name = "Dogs", Id = 10 },
            new Category { Name = "Cats", Id = 11 },
            new Category { Name = "Birds", Id = 12 }
        };

        /// <summary>
        /// Creating a single Pet object with associated Category and Tag
        /// </summary>
        var pet = new Pet
        {
            Id = 1,
            Category = new Category { Id = 12, Name = "Birds" },
            Name = "Peacock",
            PhotoUrls = new List<string> { "https://peacock.jpeg" },
            Tags = new List<Tag>
            {
                new Tag { Id = 101, Name = "Bird-P" }
            },
            Status = "sold"
        };

        // Optional: Store in an array if needed later
        Pet[] pets = new Pet[] { pet };

        // Output pet details
        Console.WriteLine("Pet Name: " + pet.Name);
        Console.WriteLine("Pet Status: " + pet.Status);
        Console.WriteLine("Category: " + pet.Category.Name);
        Console.WriteLine("Photo URL: " + pet.PhotoUrls[0]);
        Console.WriteLine("Tag: " + pet.Tags[0].Name);

        // Display the list of available categories
        Console.WriteLine("\nAvailable Categories:");
        foreach (var item in categories)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
        }

        // Wait for user input before closing
        Console.ReadLine();
    }
}
