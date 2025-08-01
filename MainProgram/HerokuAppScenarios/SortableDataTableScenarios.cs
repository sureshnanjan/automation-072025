using HerokuOperations;
namespace HerokuAppScenarios;

public class SortableDataTableScenarios
{
    private ISortableDataTables sortableTables;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_PageTitle_IsCorrect()
    {
        string expectedTitle = "The Internet";
        Assert.AreEqual(expectedTitle, sortableTables.GetTitle(), "Page title mismatch.");
    }

    [Test]
    public void Test_HeaderInformation_IsDisplayed()
    {
        string header = sortableTables.GetInformation();
        Assert.IsTrue(header.Contains("Data Tables"), $"Expected header to contain 'Data Tables' but got: {header}");
    }

    [Test]
    public void Test_Table_HasRowsAndColumns()
    {
        Assert.Greater(sortableTables.GetRowCount(), 0, "Expected at least one row.");
        Assert.Greater(sortableTables.GetColumnCount(), 0, "Expected at least one column.");
    }

    [Test]
    public void Test_GetCellValue_NotEmpty()
    {
        string cellValue = sortableTables.GetCellValue(1, 1); // Row 1, Col 1
        Assert.IsNotEmpty(cellValue, "Cell value should not be empty.");
    }

    [Test]
    public void Test_ClickEditAndDelete()
    {
        Assert.DoesNotThrow(() => sortableTables.ClickEditButton(1), "Edit button click failed.");
        Assert.DoesNotThrow(() => sortableTables.ClickDeleteButton(1), "Delete button click failed.");
    }
}
