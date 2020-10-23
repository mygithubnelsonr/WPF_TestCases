using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RundButton.xaml
    /// </summary>
    public partial class RundButton : Window
    {
        public RundButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var b = (Button) sender;

            //label.Content = b.Content;

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print($"button8.IsChecked = {button8.IsChecked}");
        }
    }
}
