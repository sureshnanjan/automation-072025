//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections;  // <-- Needed for IComparer

//namespace SystemArrayTests
//{
//    [TestClass]
//    public class SimpleSortTests
//    {
//        // Custom comparer for reverse (descending) order
//        public class ReverseComparer : IComparer
//        {
//            public int Compare(object x, object y)
//            {
//                return StringComparer.OrdinalIgnoreCase.Compare(y, x); // reverse comparison
//            }
//        }

//        [TestMethod]
//        public void ArraySort_Ascending_FirstElementIsCorrect()
//        {
//            // Arrange
//            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
//            string expected = "brown"; // alphabetically smallest (case-sensitive)

//            // Act
//            Array.Sort(words); // Sort in ascending order (default)

//            string actual = words[0]; // First element after sort

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void ArraySort_Descending_FirstElementIsCorrect()
//        {
//            // Arrange
//            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
//            string expected = "the"; // highest in reverse (case-insensitive)

//            // Act
//            Array.Sort(words, new ReverseComparer()); // Sort in reverse order

//            string actual = words[0]; // First element after reverse sort

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }
//        [TestMethod]
//        public void ArraySort_SecondLetter_IsCorrect()
//        {
//            //Arrange

//        }
//    }
//}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SystemArrayTests
{
    [TestClass]
    public class SimpleSortTests
    {
        // Custom comparer for reverse (descending) order
        public class ReverseComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return StringComparer.OrdinalIgnoreCase.Compare(y, x); // reverse comparison
            }
        }

        // Comparer to sort strings based on the second character
        public class SecondCharComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length < 2 || y.Length < 2)
                    return x.Length.CompareTo(y.Length);

                return x[1].CompareTo(y[1]);
            }
        }

        [TestMethod]
        public void ArraySort_Ascending_FirstElementIsCorrect()
        {
            // Arrange
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string expected = "brown"; // alphabetically smallest (case-sensitive)

            // Act
            Array.Sort(words); // Sort in ascending order (default)

            string actual = words[0]; // First element after sort

            // Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void ArraySort_Descending_FirstElementIsCorrect()
        //{
        //    // Arrange
        //    string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
        //    string expected = "the"; // highest in reverse (case-insensitive)

        //    // Act
        //    Array.Sort(words, new ReverseComparer()); // Sort in reverse order

        //    string actual = words[0]; // First element after reverse sort

        //    // Assert
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void ArraySort_Descending_FirstElementIsCorrect()
        {
            // Arrange
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string expected = "the"; // highest in reverse (case-insensitive)

            // Act
            Array.Sort(words, new ReverseComparer()); // Sort in reverse order

            string actual = words[0]; // First element after reverse sort

            // Assert
            Assert.IsTrue(
                string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase),
                $"Expected: {expected}, Actual: {actual}"
            );
        }
        [TestMethod]
        public void ArraySort_SecondLetter_IsCorrect()
        {
            // Arrange
            List<string> input = new List<string> { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            List<string> expected = new List<string> { "lazy", "The", "the", "fox", "dog", "brown", "quick", "jumps", "over" };

            // Act
            input.Sort(new SecondCharComparer());

            // Assert
            CollectionAssert.AreEqual(expected, input);
        }
    }
}


//Great question! Let's walk through **why this fix was necessary**, **how it works**, and **how it improves upon the original version**.

//---

//### ✅ **Original Problem**

//#### Original assertion:

//```csharp
//Assert.AreEqual(expected, actual);
//```

//*This compares strings **case-sensitively** by default.
//* So `"the"` is **not equal** to `"The"` because lowercase and uppercase letters have different ASCII/Unicode values.
//* Your sorting used a **case-insensitive comparer**, so it’s inconsistent to assert with a case-sensitive check.

//#### Result:

//```
//Assert.AreEqual failed. Expected:< the >.Actual:< The >.
//```

//---

//### ✅ **The Fix**

//#### Updated assertion:

//```csharp
//Assert.IsTrue(
//    string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase),
//    $"Expected: {expected}, Actual: {actual}"
//);
//```

//#### Explanation:

//* `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` compares** ignoring case**.
//* So `"The"` and `"the"` are treated as equal.
//* This matches your sorting logic which uses `StringComparer.OrdinalIgnoreCase`.

//---

//### ✅ **Why this fix was done**

//Because your **custom comparer** uses:

//```csharp
//StringComparer.OrdinalIgnoreCase.Compare(y, x);
//```

//…it means sorting is **case-insensitive**. So verifying the result using a **case -sensitive * *method(like `Assert.AreEqual`) causes false failures when the actual order is logically correct.

//### ✨ This fix helps by:

//| Aspect | Before(Assert.AreEqual) | After(Assert.IsTrue with OrdinalIgnoreCase) |
//| ---------------------- | ------------------------------------------ | --------------------------------------------- |
//| **Case sensitivity * *   | Case - sensitive(strict) | Case - insensitive(flexible) |
//| **Matches sort logic** | ❌ No(sort is case -insensitive)            | ✅ Yes(comparison logic matches sort logic) |
//| **Test reliability * *   | ❌ Fragile for mixed -case strings | ✅ More accurate &robust |
//| **Failure clarity * *    | ❌ Reports mismatch even if logically equal | ✅ Reports mismatch only if actually different |

//---

//### 🧠 Summary

//You're now comparing the **expected** and **actual** strings the same way your **sort logic** compares them: ignoring case. That makes your test **consistent, accurate, and meaningful**.

//Let me know if you want the same logic applied to other tests or a stricter comparison strategy!
