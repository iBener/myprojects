using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Bener.DataVisualizer
{
    class MainWindow : Window
    {

        internal Grid Grid { get; set; }

        public MainWindow()
        {
            this.Title = "Bener Dictionary Visualizer";
            this.Width = 800;
            this.Height = 600;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid = new Grid();
            this.Content = Grid;

            var dg = new DataGrid();
            var c = new DataGridTextColumn();
            c.Header = "Merhaba";
            dg.Columns.Add(c);
            Grid.Children.Add(dg);

        }

    }
}
