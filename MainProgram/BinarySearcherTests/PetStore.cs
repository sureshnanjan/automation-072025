// Author: Siva Sree
// Date Created: 2025-07-27
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file contains unit tests to demonstrate the use of the Array.BinarySearch() method
// using a custom comparer. It shows different test cases including successful search,
// unsuccessful search, empty range search, and how the method handles a null comparer.
// This file uses MSTest for writing unit tests, and helps understand binary search behavior
// within a specified range using a custom IComparer implementation.

using System.Collections;
using System.Collections.Generic;

namespace BinarySearchAdvancedTests
{
    internal class PetStore : IEnumerable<PetStore>
    {
        public IEnumerator<PetStore> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}