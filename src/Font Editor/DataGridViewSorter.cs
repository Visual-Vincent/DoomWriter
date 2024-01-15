using System;
using System.Windows.Forms;
using DoomWriter;

namespace FontEditor
{
    /// <summary>
    /// A static class providing helper methods for sorting data in a <see cref="DataGridView"/>.
    /// </summary>
    public static class DataGridViewSorter
    {
        /// <summary>
        /// Handles the <see cref="DataGridView.SortCompare"/> event and sorts the specified column(s) containing single characters.
        /// </summary>
        /// <param name="e">The event data from the <see cref="DataGridView.SortCompare"/>.</param>
        public static void SortByCharacterColumns(DataGridViewSortCompareEventArgs e)
        {
            char? c1 = null;
            char? c2 = null;

            if(e.CellValue1 != null)
            {
                if(e.CellValue1 is char)
                {
                    c1 = (char)e.CellValue1;
                }
                else
                {
                    if(!(e.CellValue1 is string str))
                        return; // Unknown value, let the system handle sorting

                    if(str.Length > 0)
                        c1 = str[0];
                }
            }

            if(e.CellValue2 != null)
            {
                if(e.CellValue2 is char)
                {
                    c2 = (char)e.CellValue2;
                }
                else
                {
                    if(!(e.CellValue2 is string str))
                        return; // Unknown value, let the system handle sorting

                    if(str.Length > 0)
                        c2 = str[0];
                }
            }

            if(!c1.HasValue && !c2.HasValue)
            {
                e.SortResult = 0;
                e.Handled = true;
                return;
            }
            else if(c1.HasValue && !c2.HasValue)
            {
                e.SortResult = -1;
                e.Handled = true;
                return;
            }
            else if(!c1.HasValue && c2.HasValue)
            {
                e.SortResult = 1;
                e.Handled = true;
                return;
            }

            e.SortResult = CharComparer.Default.Compare(c1.Value, c2.Value);
            e.Handled = true;
        }
    }
}
