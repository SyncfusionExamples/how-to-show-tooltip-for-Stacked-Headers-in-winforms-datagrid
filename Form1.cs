using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;

            var stackedHeaderRow1 = new StackedHeaderRow();

            //Adding stacked column to stacked columns collection available in stacked header row object.
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn() { ChildColumns = "OrderID,OrderDate", HeaderText = "Order Details" });
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn() { ChildColumns = "CustomerID", HeaderText = "Customer Details" });
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn() { ChildColumns = "ProductName,Quantity,UnitPrice", HeaderText = "Product Details" });

            //Adding stacked header row object to stacked header row collection available in SfDataGrid.
            sfDataGrid1.StackedHeaderRows.Add(stackedHeaderRow1);

            this.sfDataGrid1.TableControl.MouseMove += OnTableControl_MouseMove;
        }

        RowColumnIndex hoveredRowcolumnIndex = new RowColumnIndex(-1, -1);
        SfToolTip Tooltip = new SfToolTip();

        private void OnTableControl_MouseMove(object sender, MouseEventArgs e)
        {
            var rowColumnIndex = this.sfDataGrid1.TableControl.PointToCellRowColumnIndex(e.Location, true);
            if (hoveredRowcolumnIndex != rowColumnIndex && rowColumnIndex.RowIndex == 0)
            {
                Tooltip.Hide();
                if (rowColumnIndex.ColumnIndex == 0)
                    Tooltip.Show("StackedHeaderCell 1");
                if (rowColumnIndex.ColumnIndex == 1)
                    Tooltip.Show("StackedHeaderCell 2");
            }
            else if (rowColumnIndex.RowIndex > 0)
                Tooltip.Hide();
            hoveredRowcolumnIndex = rowColumnIndex;
        }

        #endregion
    }
}
