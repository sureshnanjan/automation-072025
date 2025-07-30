// Import required namespaces
using Microsoft.VisualStudio.TestTools.UnitTesting;   // MSTest framework for unit testing
using System;                                        // Provides base .NET classes
using System.Collections.Generic;                    // Provides generic collections like List<T>, IEqualityComparer
using System.Linq;                                   // Provides LINQ for querying collections

namespace CollectionTests // Namespace to group related test classes
{
    // ----------------------------
    // Custom class representing a Student entity
    // ----------------------------
    public class Student
    {
        public int Id { get; set; }     // Unique identifier for each student
        public string Name { get; set; } // Name of the student
    }

    // ----------------------------
    // Custom comparer implementing IEqualityComparer<Student>
    // Used for comparing Student objects based on their Id
    // ----------------------------
    public class StudentComparer : IEqualityComparer<Student>
    {
        // Method to compare two students by their Id
        public bool Equals(Student x, Student y)
        {
            return x.Id == y.Id; // Students are considered equal if their IDs match
        }

        // Method to get hash code for a student (used in collections like Dictionary or HashSet)
        public int GetHashCode(Student obj)
        {
            return obj.Id.GetHashCode(); // Returns hash code based on student ID
        }
    }

    // ----------------------------
    // Test class for performing CRUD operations on the Student list
    // ----------------------------
    [TestClass] // Marks this as a test class for MSTest
    public class StudentCrudTests
    {
        private List<Student> _students;             // Collection to store Student objects
        private IEqualityComparer<Student> _comparer; // Custom comparer instance

        // Runs before each test to create a fresh data setup
        [TestInitialize]
        public void Setup()
        {
            _students = new List<Student>();       // Initializes empty student list
            _comparer = new StudentComparer();     // Initializes custom comparer
        }

        // ---------- CREATE ----------
        // Test to verify adding a student increases the count
        [TestMethod]
        public void Create_AddStudent_ShouldIncreaseCount()
        {
            _students.Add(new Student { Id = 1, Name = "Alice" }); // Adds a new student
            Assert.AreEqual(1, _students.Count); // Asserts that the list now contains one student
        }

        // ---------- READ ----------
        // Test to read a student by Id
        [TestMethod]
        public void Read_FindStudentById_ShouldReturnCorrectStudent()
        {
            _students.Add(new Student { Id = 1, Name = "Alice" });  // Adds first student
            _students.Add(new Student { Id = 2, Name = "Bob" });    // Adds second student

            var student = _students.FirstOrDefault(s => s.Id == 2); // Finds student with Id=2

            Assert.IsNotNull(student);                             // Ensures student is found
            Assert.AreEqual("Bob", student.Name);                  // Verifies correct student is returned
        }

        // ---------- UPDATE ----------
        // Test to update a student's name
        [TestMethod]
        public void Update_ChangeStudentName_ShouldReflectUpdatedValue()
        {
            var student = new Student { Id = 1, Name = "Alice" };
            _students.Add(student); // Adds student

            var existing = _students.FirstOrDefault(s => s.Id == 1); // Finds student by Id
            if (existing != null)
            {
                existing.Name = "Alice Updated"; // Updates name
            }

            Assert.AreEqual("Alice Updated", _students.First().Name); // Verifies updated name
        }

        // ---------- DELETE ----------
        // Test to delete a student by Id
        [TestMethod]
        public void Delete_RemoveStudent_ShouldDecreaseCount()
        {
            _students.Add(new Student { Id = 1, Name = "Alice" });   // Adds first student
            _students.Add(new Student { Id = 2, Name = "Bob" });     // Adds second student

            var studentToRemove = _students.FirstOrDefault(s => s.Id == 1); // Finds student with Id=1
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove); // Removes student
            }

            Assert.AreEqual(1, _students.Count);   // Ensures only one student remains
        }

        // ---------- ENUMERABLE ----------
        // Test to iterate over the student list using IEnumerable
        [TestMethod]
        public void Enumerable_ShouldIterateOverAllStudents()
        {
            // Arrange: Add multiple students
            _students.Add(new Student { Id = 1, Name = "Alice" });
            _students.Add(new Student { Id = 2, Name = "Bob" });
            _students.Add(new Student { Id = 3, Name = "Charlie" });

            // Act: Convert IEnumerable to a list for easier verification
            IEnumerable<Student> enumerableStudents = _students;  // List implements IEnumerable
            var names = enumerableStudents.Select(s => s.Name).ToList(); // Extracts all names

            // Assert: Verify that all names are returned in insertion order
            CollectionAssert.AreEqual(new List<string> { "Alice", "Bob", "Charlie" }, names);
        }
    }
}
