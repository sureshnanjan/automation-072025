/***********************************************************************************
* File Name    : FileOperationsDemo.cs
* Author       : SHREYA S G
* Created Date : 26-Jul-2025
* Description  : Demonstrates basic file operations using the System.IO namespace.
*                Implements 5 methods of the File class (WriteAllText, ReadAllText,
*                AppendAllText, Copy, GetAttributes) with proper documentation.
* Copyright    : © 2025 Your Name. All rights reserved.
************************************************************************************/

using System;
using System.IO;  // Required for File operations

namespace Week4Assignments
{
    /// <summary>
    /// A demo class that performs basic file operations using System.IO.File class.
    /// </summary>
    class FileOperationsDemo
    {
        /// <summary>
        /// Entry point of the program. Demonstrates 5 File class methods.
        /// </summary>
        /// <param name="args">Command-line arguments (not used here).</param>
        static void Main(string[] args)
        {
            // Define file paths
            string filePath = "testfile.txt";      // Path for the main file
            string copyPath = "copy_testfile.txt"; // Path for the copied file

            // 1. WriteAllText - Create and write content to a new file.
            // If the file exists, it overwrites it.
            File.WriteAllText(filePath, "Hello, this is the first line.");
            Console.WriteLine("1. File created and initial text written.");

            // 2. ReadAllText - Read the content of the file as a single string.
            string content = File.ReadAllText(filePath);
            Console.WriteLine("2. File content: " + content);

            // 3. AppendAllText - Add more content to the existing file without overwriting.
            File.AppendAllText(filePath, "\nThis is an appended line.");
            Console.WriteLine("3. Additional text appended.");

            // 4. Copy - Create a copy of the file at a new location (overwrites if already exists).
            File.Copy(filePath, copyPath, true);
            Console.WriteLine("4. File copied to: " + copyPath);

            // 5. GetAttributes - Fetch metadata about the file (like ReadOnly, Hidden, Archive).
            FileAttributes attributes = File.GetAttributes(filePath);
            Console.WriteLine("5. File attributes: " + attributes);

            // Final message
            Console.WriteLine("\nAll file operations completed successfully.");
        }
    }
}
