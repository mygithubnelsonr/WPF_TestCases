using DasDataGrid.DataAccess;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DasDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datagrid.DataContext = DataLoader.LoadEmployees();
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Homepage"
             || e.PropertyName == "Responsibilities")
            {
                e.Cancel = true;
            }
            else if (e.PropertyName == "FirstName")
            {
                e.Column.Header = "Vorname";
            }
            else if (e.PropertyName == "LastName")
            {
                e.Column.Header = "Nachname";
            }
        }

        private void dataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.Print("DataGrid_MouseRightButtonUp");
        }

        private void dataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.Print("DataGrid_MouseRightButtonDown");

            var row = Grid.GetRow(datagrid);
            var col = Grid.GetColumn(datagrid);

            Debug.Print(row.ToString());
            Debug.Print(col.ToString());

        }


    }
}
