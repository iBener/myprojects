using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Bener.DataVisualizer
{
    class VisualizerWindow : Window
    {
        private DataView vItems;
        private List<string> filters;

        internal Grid Grid { get; private set; }
        internal DataGrid DataGrid { get; private set; }
        internal TextBox FilterText { get; private set; }

        public VisualizerWindow()
        {
            Grid = new Grid();
            // this
            this.Title = "Bener Dictionary Visualizer";
            this.Width = 800;
            this.Height = 600;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Content = Grid;
            // label
            var lbl = new Label();
            lbl.Content = "Filter";
            lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            lbl.Margin = new Thickness(10, 6, 0, 0);
            lbl.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            lbl.Height = 26;
            lbl.Width = 48;
            // filter text
            FilterText = new TextBox();
            FilterText.Height = 23.0;
            FilterText.Margin = new Thickness(53, 10, 22, 0);
            FilterText.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            FilterText.TextChanged += txt_TextChanged;
            // datagrid
            DataGrid = new DataGrid();
            DataGrid.Margin = new Thickness(10, 40, 10, 10);
            // childrens
            Grid.Children.Add(lbl);
            Grid.Children.Add(FilterText);
            Grid.Children.Add(DataGrid);
        }

        void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilterText.Text))
            {
                vItems.RowFilter = "";
                return;
            }
            var filterText = FilterText.Text + "*";
            var l = new List<string>();
            foreach (var f in filters)
            {
                l.Add(String.Format(f, filterText));
            }
            var filter = String.Join(" or ", l.ToArray());
            vItems.RowFilter = filter;
        }

        public void SetDataSource(VisualizerDataSource ds)
        {
            vItems = ds.DataTable.DefaultView;
            DataGrid.ItemsSource = vItems;
            DataGrid.AutoGenerateColumns = true;
            DataGrid.CanUserAddRows = false;
            DataGrid.CanUserDeleteRows = false;
            DataGrid.IsReadOnly = true;
            DataGrid.SelectionUnit = DataGridSelectionUnit.Cell;
            // filter columns
            filters = new List<string>();
            foreach (DataColumn col in ds.DataTable.Columns)
            {
                filters.Add(col.ColumnName + " like '{0}'");
            }
        }

    }
}
