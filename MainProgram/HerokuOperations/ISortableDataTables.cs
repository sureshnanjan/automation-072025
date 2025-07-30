using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface SortableDataTables
    {
        void GoToPage();

        string GetTitle();

        string GetInformation();

        int GetRowCount();

        int GetColumnCount();

        string GetCellValue(int row, int column);

        void ClickEditButton(int row);

        void ClickDeleteButton(int row);
    }
}
