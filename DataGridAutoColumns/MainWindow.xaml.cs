using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DasDataGrid.DataAccess;
using System.ComponentModel;

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
      this.DataContext = DataLoader.LoadEmployees();
    }

    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
  }
}
