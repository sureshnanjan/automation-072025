// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
// 
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// --------------------------------------------------------------------------------------

using HerokuOperations;
using NUnit.Framework;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class TyposPageTests
    {
        private ITyposPage _typosPage;

        [SetUp]
        public void Setup()
        {
            // Normally, you'd initialize a concrete implementation of ITyposPage here.
            // Example:
            // _typosPage = new TyposPageImplementation();
        }

        [Test]
        public void NavigateToPage_ShouldReturnExpectedTitle()
        {
            // Arrange
            string expectedTitle = "Typos Page";

            // Act
            _typosPage.NavigateToPage();
            string actualTitle = _typosPage.GetPageTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected value.");
        }

        [Test]
        public void NavigateToPage_ShouldReturnExpectedDescription()
        {
            // Arrange
            string expectedDescription = "This is a sample page to check for typos.";

            // Act
            _typosPage.NavigateToPage();
            string actualDescription = _typosPage.GetPageDescription();

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription, "Page description does not match expected value.");
        }

        [Test]
        public void Page_ShouldNotContainAnyTypos()
        {
            // Arrange
            _typosPage.NavigateToPage();

            // Act
            bool hasTypos = _typosPage.HasTypos();

            // Assert
            Assert.IsFalse(hasTypos, "Page contains typos, which is unexpected.");
        }
    }
}
