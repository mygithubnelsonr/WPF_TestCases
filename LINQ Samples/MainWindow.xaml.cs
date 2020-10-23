using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Entity;

namespace LINQ_Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button001_Click(object sender, RoutedEventArgs e)
        {
            QueryList queryList = new QueryList();
            var list = queryList.Load();
            var itemExist = list.Any(i => i.Name.Contains(textbox01.Text));
            output.Text = $"{itemExist}";

        }
    }
}
