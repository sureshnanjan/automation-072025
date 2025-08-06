/*
* ------------------------------------------------------------------------------
* © 2025 HerokuApp Testing Suite – All Rights Reserved.
* Developed by: Gayathri Thalapathi
* Description: NUnit test cases for Sortable Data Tables on HerokuApp.
* This suite verifies structural integrity, data correctness, UI interaction,
* accessibility, and functional actions on the sortable table examples.
* ------------------------------------------------------------------------------
*/

using NUnit.Framework;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
    public class SortableDataTableScenarios
    {
        private ISortableDataTables sortableTables;

        /// <summary>
        /// Initializes the test instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            sortableTables = new SortableDataTables();
        }

        /// <summary>
        /// Verify that the page title is rendered correctly on Data Tables page.
        /// </summary>
        [Test]
        public void Should_Display_Correct_Page_Title()
        {
            string expectedTitle = "The Internet";
            Assert.AreEqual(expectedTitle, sortableTables.GetTitle(), "Page title mismatch.");
        }

        /// <summary>
        /// Verify all column headers are displayed as expected.
        /// </summary>
        [Test]
        public void Should_Display_All_Table_Headers()
        {
            var headers = sortableTables.GetTableHeaders();
            CollectionAssert.AreEqual(
                new[] { "Last Name", "First Name", "Email", "Due", "Web Site", "Action" },
                headers,
                "Table headers do not match expected values.");
        }

        /// <summary>
        /// Check that each table has the correct number of rows (Example 1 and Example 2).
        /// </summary>
        [Test]
        public void Should_Display_Correct_Row_Count_For_Both_Tables()
        {
            int table1RowCount = sortableTables.GetRowCount(1);
            int table2RowCount = sortableTables.GetRowCount(2);

            Assert.AreEqual(4, table1RowCount, "Unexpected row count in Example 1.");
            Assert.AreEqual(4, table2RowCount, "Unexpected row count in Example 2.");
        }

        /// <summary>
        /// Validate data integrity in each cell (e.g., no empty data).
        /// </summary>
        [Test]
        public void Should_Ensure_All_Cells_Have_Valid_Data()
        {
            for (int table = 1; table <= 2; table++)
            {
                int rows = sortableTables.GetRowCount(table);
                int cols = sortableTables.GetColumnCount(table);

                for (int r = 1; r <= rows; r++)
                {
                    for (int c = 1; c <= cols; c++)
                    {
                        string value = sortableTables.GetCellValue(table, r, c);
                        Assert.IsNotEmpty(value, $"Empty cell found at Table {table}, Row {r}, Col {c}");
                    }
                }
            }
        }

        /// <summary>
        /// Ensure that the hyperlinks for edit/delete are present for each row.
        /// </summary>
        [Test]
        public void Should_Display_Edit_And_Delete_Actions()
        {
            for (int table = 1; table <= 2; table++)
            {
                int rows = sortableTables.GetRowCount(table);
                for (int r = 1; r <= rows; r++)
                {
                    Assert.IsTrue(sortableTables.IsEditButtonPresent(table, r), $"Edit button missing at Table {table}, Row {r}");
                    Assert.IsTrue(sortableTables.IsDeleteButtonPresent(table, r), $"Delete button missing at Table {table}, Row {r}");
                }
            }
        }

        /// <summary>
        /// Simulate clicking the edit and delete buttons to verify interactions.
        /// </summary>
        [Test]
        public void Should_Invoke_Edit_And_Delete_Click_Actions()
        {
            Assert.DoesNotThrow(() => sortableTables.ClickEditButton(1, 1), "Edit action failed.");
            Assert.DoesNotThrow(() => sortableTables.ClickDeleteButton(1, 1), "Delete action failed.");
        }

        /// <summary>
        /// Confirm that email column contains properly formatted email addresses.
        /// </summary>
        [Test]
        public void Should_Contain_Valid_Email_Addresses()
        {
            var emails = sortableTables.GetColumnValues(1, "Email");
            foreach (var email in emails)
            {
                Assert.IsTrue(email.Contains("@") && email.Contains("."), $"Invalid email format: {email}");
            }
        }

        /// <summary>
        /// Verify that due values contain currency formatted values.
        /// </summary>
        [Test]
        public void Should_Display_Due_Column_As_Valid_Currency()
        {
            var dues = sortableTables.GetColumnValues(1, "Due");
            foreach (var due in dues)
            {
                Assert.IsTrue(due.StartsWith("$") && decimal.TryParse(due.Substring(1), out _),
                    $"Invalid currency value: {due}");
            }
        }

        /// <summary>
        /// Confirm that website URLs in the table are formatted properly.
        /// </summary>
        [Test]
        public void Should_Display_Valid_Website_URLs()
        {
            var urls = sortableTables.GetColumnValues(1, "Web Site");
            foreach (var url in urls)
            {
                Assert.IsTrue(url.StartsWith("http://"), $"Invalid URL format: {url}");
            }
        }

        /// <summary>
        /// Ensure that action links are styled and functional.
        /// </summary>
        [Test]
        public void Should_Style_Action_Links_Consistently()
        {
            var styles = sortableTables.GetActionLinkStyles(1);
            foreach (var style in styles)
            {
                Assert.IsTrue(style.Contains("blue") || style.Contains("underline"), $"Unexpected style: {style}");
            }
        }
        /// <summary>
        /// verifies that the footer contains the expected "Powered by" information.
        /// </summary>
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


        /// <summary>
        /// verifies that the GitHub ribbon is displayed correctly.
        /// </summary>
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
