using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LINQ_Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Query> queries;
        private string _selectedComboboxItemText = "";

        public MainWindow()
        {
            InitializeComponent();

            QueryList queryList = new QueryList();
            queries = queryList.Load();
            combobox.ItemsSource = queries.OrderBy(i => i.Name); ;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            textblockStatus.Text = "";
            try
            {
                if (checkboxAnyContains.IsChecked == true)
                {
                    bool itemExist = queries.Any(i => i.Name.Contains(_selectedComboboxItemText));
                    textblockStatus.Text = $"List contains {_selectedComboboxItemText}={itemExist}";
                }

                if (checkboxIndexOf.IsChecked == true)
                {
                    var result = queries.IndexOf(queries.Single(i => i.Name == _selectedComboboxItemText));
                    textblockStatus.Text = $"Index of {_selectedComboboxItemText}={result}";
                }
                if (checkboxMinMax.IsChecked == true)
                {
                    int minRow = queries.Min(r => r.Row);
                    int maxRow = queries.Max(r => r.Row);
                    textblockStatus.Text = $"Min Row= {minRow}, Max Row={maxRow}";
                }
            }
            catch (Exception ex)
            {
                textblockStatus.Text = ex.Message;
            }
        }

        private void combobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboItem = (Query)combobox.SelectedItem;
            _selectedComboboxItemText = comboItem.Name;
        }
    }
}
