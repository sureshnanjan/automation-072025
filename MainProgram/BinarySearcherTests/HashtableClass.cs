using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace BinarySearcherTests;

[TestClass]
public class HashtableClass
{
    public Hashtable employees;
    [TestInitialize]
    public void Initialize()
    {
        // Initialization code here
        employees = new Hashtable
        {
            { "John", 30 },
            { "Jane", 25 },
            { "Doe", 40}

        };
        
    }

    [TestMethod]
    public void Test_Create_NewEmployee()
    {
        // Arrange
        var newEmployeeName = "Alice";
        var newEmployeeAge = 28;
        // Act
        employees.Add(newEmployeeName, newEmployeeAge);
        // Assert
        Assert.IsTrue(employees.ContainsKey(newEmployeeName));
        Assert.AreEqual(newEmployeeAge, employees[newEmployeeName]);

    }
    [TestMethod]
    public void Test_Read_employee()
    {
        // Arrange
        var employeeName = "John";
        var expectedAge = 30;
        // Act
        var employeeAge = employees[employeeName];
        // Assert
        Assert.IsNotNull(employeeAge);
        Assert.AreEqual(expectedAge, employeeAge);

    }
    [TestMethod]
    public void Test_Update_employee()
    {
        // Arrange
        var employeeName = "Jane";
        var newAge = 26;
        // Act
        employees[employeeName] = newAge;
        // Assert
        Assert.AreEqual(newAge, employees[employeeName]);

    }
    [TestMethod]
    public void Test_Delete_employee()
    {
        // Arrange
        var employeeName = "Jane";

        // Act
        employees.Remove(employeeName);

        // Assert
        Assert.IsFalse(employees.ContainsKey(employeeName));
    }

    [TestMethod]
    public void Test_Enumerate_employees()
    {
        // Arrange
        var expectedCount = 3; // Initial count before adding "Alice"
        // Act
        var count = employees.Count;
        // Assert
        Assert.AreEqual(expectedCount, count);
        // Adding a new employee to check enumeration
        employees.Add("Alice", 28);
        expectedCount++;
        count = employees.Count;
        Assert.AreEqual(expectedCount, count);


        /*    public struct DictionaryEntry
              {
                    public object Key { get; }
                    public object Value { get; }
              }
        */
        foreach (DictionaryEntry entry in employees)
        {
            Assert.IsNotNull(entry.Key);
            Assert.IsNotNull(entry.Value);
        }

        /*
                All keys exist.

                All values are filled in.
        */
    }
}
