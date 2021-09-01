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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Statusbar
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

        private void buttonSb1_Click(object sender, RoutedEventArgs e)
        {
            sbaudio.Visibility = Visibility.Visible;
            sbplaylist.Visibility = Visibility.Hidden;
        }

        private void buttonSb2_Click(object sender, RoutedEventArgs e)
        {
            sbplaylist.Visibility = Visibility.Visible;
            sbaudio.Visibility = Visibility.Hidden;
        }
    }
}
