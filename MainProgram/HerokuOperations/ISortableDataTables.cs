using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface ISortableDataTables
    {
        void GoToPage(); //Navigate to the sortable data tables page

        string GetTitle(); // Get the title of the page

        string GetInformation();// Get the information text on the page

        int GetRowCount();// Get the number of rows in the table

        int GetColumnCount();// Get the number of columns in the table

        string GetCellValue(int row, int column);// Get the value of a specific cell in the table

        void ClickEditButton(int row);// Click the edit button for a specific row

        void ClickDeleteButton(int row);// Click the delete button for a specific row
    }
}
