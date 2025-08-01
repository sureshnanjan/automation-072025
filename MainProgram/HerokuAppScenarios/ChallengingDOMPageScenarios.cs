// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
// 
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This interface defines the contract for interacting with the Basic Auth page functionality,
// including navigation, credential handling via browser alerts, and content validation.
// -------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuTests
{
    /// <summary>
    /// Test suite for the Challenging DOM Page on HerokuApp.
    /// Validates buttons, table content, edit/delete actions, and dynamic UI behavior.
    /// </summary>
    [TestFixture]
    public class ChallengingDOMPageTests
    {
        private ChallengingDOMPage _domPage;

        [SetUp]
        public void SetUp()
        {
            // Typically you'd initialize the _domPage with a driver here.
            // Example: _domPage = new ChallengingDOMPage(driver);
        }

        // ---------------- Page Meta Tests ----------------

        /// <summary>
        /// Validates that the page title matches the expected value.
        /// </summary>
        [Test]
        public void PageTitleIsCorrect()
        {
            // Arrange
            string expectedTitle = "Challenging DOM";

            // Act
            string actualTitle = _domPage.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        /// <summary>
        /// Verifies that the page description text is as expected.
        /// </summary>
        [Test]
        public void PageDescriptionIsCorrect()
        {
            // Arrange
            string expectedDescription = "The hardest part in automated web testing is finding the best locators (e.g., ones that well named, unique, and unlikely to change). It's more often than not that the application you're testing was not built with this concept in mind. This example demonstrates that with unique IDs, a table with no helpful locators, and a canvas element.";

            // Act
            string actualDescription = _domPage.Description;

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        // ---------------- Button Tests ----------------

        /// <summary>
        /// Ensures Blue button is clickable.
        /// </summary>
        [Test]
        public void BlueButtonIsClickable()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => _domPage.ClickBlueButton());
        }

        /// <summary>
        /// Ensures Red button is clickable.
        /// </summary>
        [Test]
        public void RedButtonIsClickable()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => _domPage.ClickRedButton());
        }

        /// <summary>
        /// Ensures Green button is clickable.
        /// </summary>
        [Test]
        public void GreenButtonIsClickable()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => _domPage.ClickGreenButton());
        }

        /// <summary>
        /// Verifies Blue button updates the answer box.
        /// </summary>
        [Test]
        public void Should_DisplayAnswerBoxChange_When_BlueButtonClicked()
        {
            // Arrange
            string initial = _domPage.GetAnswerBoxText();

            // Act
            _domPage.ClickBlueButton();
            string updated = _domPage.GetAnswerBoxText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        /// <summary>
        /// Verifies Red button updates the answer box.
        /// </summary>
        [Test]
        public void Should_DisplayAnswerBoxChange_When_RedButtonClicked()
        {
            // Arrange
            string initial = _domPage.GetAnswerBoxText();

            // Act
            _domPage.ClickRedButton();
            string updated = _domPage.GetAnswerBoxText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        /// <summary>
        /// Verifies Green button updates the answer box.
        /// </summary>
        [Test]
        public void Should_DisplayAnswerBoxChange_When_GreenButtonClicked()
        {
            // Arrange
            string initial = _domPage.GetAnswerBoxText();

            // Act
            _domPage.ClickGreenButton();
            string updated = _domPage.GetAnswerBoxText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        /// <summary>
        /// Verifies the Blue button label changes after click.
        /// </summary>
        [Test]
        public void Should_ChangeBlueButtonText_When_Clicked()
        {
            // Arrange
            string initial = _domPage.GetBlueButtonText();

            // Act
            _domPage.ClickBlueButton();
            string updated = _domPage.GetBlueButtonText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        /// <summary>
        /// Verifies the Red button label changes after click.
        /// </summary>
        [Test]
        public void Should_ChangeRedButtonText_When_Clicked()
        {
            // Arrange
            string initial = _domPage.GetRedButtonText();

            // Act
            _domPage.ClickRedButton();
            string updated = _domPage.GetRedButtonText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        /// <summary>
        /// Verifies the Green button label changes after click.
        /// </summary>
        [Test]
        public void Should_ChangeGreenButtonText_When_Clicked()
        {
            // Arrange
            string initial = _domPage.GetGreenButtonText();

            // Act
            _domPage.ClickGreenButton();
            string updated = _domPage.GetGreenButtonText();

            // Assert
            Assert.AreNotEqual(initial, updated);
        }

        // ---------------- Table Tests ----------------

        /// <summary>
        /// Verifies that table headers match expected values.
        /// </summary>
        [Test]
        public void Should_DisplayCorrectTableHeaders()
        {
            // Arrange
            var expected = new List<string> { "Lorem", "Ipsum", "Dolor", "Sit", "Amet", "Diceret", "Action" };

            // Act
            var actual = _domPage.GetTableHeaders();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates table contains exactly 10 rows.
        /// </summary>
        [Test]
        public void Should_HaveTenRowsInTable()
        {
            // Act
            int rowCount = _domPage.GetTableRowCount();

            // Assert
            Assert.AreEqual(10, rowCount);
        }

        /// <summary>
        /// Validates each row has exactly 7 columns.
        /// </summary>
        [Test]
        public void Should_EachRowHaveSevenColumns()
        {
            // Act & Assert
            for (int i = 0; i < _domPage.GetTableRowCount(); i++)
                Assert.AreEqual(7, _domPage.GetColumnCountInRow(i));
        }

        /// <summary>
        /// Ensures all cells contain non-empty data.
        /// </summary>
        [Test]
        public void Should_TableCellsNotBeEmpty()
        {
            // Act & Assert
            for (int i = 0; i < _domPage.GetTableRowCount(); i++)
                foreach (var cell in _domPage.GetRowData(i))
                    Assert.IsFalse(string.IsNullOrWhiteSpace(cell));
        }

        /// <summary>
        /// Ensures no extra unexpected rows are present.
        /// </summary>
        [Test]
        public void Should_NotHaveExtraRowsBeyondExpected()
        {
            // Act
            int count = _domPage.GetTableRowCount();

            // Assert
            Assert.LessOrEqual(count, 10);
        }


        /// <summary>
        /// Verifies that cells are not editable unless 'Edit' is clicked.
        /// </summary>
        [Test]
        public void Should_CellsNotBeEditableWithoutClickingEdit()
        {
            // Act & Assert
            for (int i = 0; i < _domPage.GetTableRowCount(); i++)
                Assert.IsFalse(_domPage.IsRowEditable(i));
        }

        /// <summary>
        /// Ensures row becomes editable after clicking 'Edit'.
        /// </summary>
        [Test]
        public void Should_CellsBecomeEditableAfterClickingEdit()
        {
            // Act
            _domPage.ClickEdit(0);

            // Assert
            Assert.IsTrue(_domPage.IsRowEditable(0));
        }

        /// <summary>
        /// Confirms each row contains an Edit button.
        /// </summary>
        [Test]
        public void Should_HaveEditButtonsInAllRows()
        {
            // Act & Assert
            for (int i = 0; i < _domPage.GetTableRowCount(); i++)
                Assert.IsTrue(_domPage.HasEditButton(i));
        }

        /// <summary>
        /// Confirms each row contains a Delete button.
        /// </summary>
        [Test]
        public void Should_HaveDeleteButtonsInAllRows()
        {
            // Act & Assert
            for (int i = 0; i < _domPage.GetTableRowCount(); i++)
                Assert.IsTrue(_domPage.HasDeleteButton(i));
        }

        /// <summary>
        /// Ensures modal is shown after clicking Edit.
        /// </summary>
        [Test]
        public void Should_DisplayEditModal_When_EditButtonClicked()
        {
            // Act
            _domPage.ClickEdit(0);

            // Assert
            Assert.IsTrue(_domPage.IsEditModalDisplayed());
        }

        /// <summary>
        /// Validates row count decreases after deleting a row.
        /// </summary>
        [Test]
        public void Should_RemoveRowAfterDeleteClick()
        {
            // Arrange
            int initial = _domPage.GetTableRowCount();

            // Act
            _domPage.ClickDelete(0);
            int updated = _domPage.GetTableRowCount();

            // Assert
            Assert.AreEqual(initial - 1, updated);
        }

        // ---------------- Dynamic Answer Box Tests ----------------

        /// <summary>
        /// Validates Blue and Red buttons generate different answers.
        /// </summary>
        [Test]
        public void Should_AnswerDifferBetween_BlueAndRedButtonClick()
        {
            // Act
            string blue = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickBlueButton);
            string red = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickRedButton);

            // Assert
            Assert.AreNotEqual(blue, red);
        }

        /// <summary>
        /// Validates Red and Green buttons generate different answers.
        /// </summary>
        [Test]
        public void Should_AnswerDifferBetween_RedAndGreenButtonClick()
        {
            // Act
            string red = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickRedButton);
            string green = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickGreenButton);

            // Assert
            Assert.AreNotEqual(red, green);
        }


        /// <summary>
        /// Validates Blue and Green buttons generate different answers.
        /// </summary>
        [Test]
        public void Should_AnswerDifferBetween_BlueAndGreenButtonClick()
        {
            // Act
            string blue = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickBlueButton);
            string green = _domPage.ClickButtonAndReturnAnswer(_domPage.ClickGreenButton);

            // Assert
            Assert.AreNotEqual(blue, green);
        }

        // ---------------- Additional Tests You May Add ----------------

        /// <summary>
        /// Validates that deleting a row removes the correct content.
        /// </summary>
        [Test]
        public void Should_DeleteCorrectRowData()
        {
            // Arrange
            var rowDataBefore = _domPage.GetRowData(0);

            // Act
            _domPage.ClickDelete(0);
            var newRowData = _domPage.GetRowData(0);

            // Assert
            CollectionAssert.AreNotEqual(rowDataBefore, newRowData);
        }

        /// <summary>
        /// Validates that editing updates content correctly (if supported).
        /// </summary>
        [Test]
        public void Should_UpdateCellContent_When_Edited()
        {
            // Arrange
            string newValue = "UpdatedValue";
            _domPage.ClickEdit(0);

            // Act
            _domPage.UpdateCell(0, 1, newValue);
            _domPage.SaveEdit(0);
            string cellText = _domPage.GetCellValue(0, 1);

            // Assert
            Assert.AreEqual(newValue, cellText);
        }

        // ───────────── FOOTER & EXTERNAL LINKS ─────────────//

        ///<summary>
        ///Validating the footer is present or not
        ///</summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        ///<summary>
        ///Validating the right side git link is present or not
        ///</summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }
    }
}
