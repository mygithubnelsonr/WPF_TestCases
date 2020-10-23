using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TabControl
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

        private void ContextMenuClickEventHandler(object sender, RoutedEventArgs e)
        {
            ContextMenu menu = sender as ContextMenu;
            var items = menu.Items;

            foreach (MenuItem item in items)
            {
                //Debug.Print(item.Header.ToString());
            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = tabControl1.SelectedItem as TabItem;
            Debug.Print($"{tabItem.Header.ToString()}");

            var x = tabItem.Content;

        }

        private void RedMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print(RedMenuItem.Header.ToString());
            TabItem tabItem = tabControl1.SelectedItem as TabItem;
            tabItem.Background = Brushes.Red;
        }

        private void BlueMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print(BlueMenuItem.Header.ToString());
            TabItem tabItem = tabControl1.SelectedItem as TabItem;
            tabItem.Background = Brushes.Blue;
        }

        private void OrangeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print(OrangeMenuItem.Header.ToString());
            TabItem tabItem = tabControl1.SelectedItem as TabItem;
            tabItem.Background = Brushes.Orange;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;

        }
    }
}
