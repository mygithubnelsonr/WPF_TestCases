using System;
using System.Windows;

namespace Listbox2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void buttonGenre_Checked(object sender, RoutedEventArgs e)
        {
            listboxGenre.Height = 0;
            rdgenre.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void buttonGenre_Unchecked(object sender, RoutedEventArgs e)
        {
            listboxGenre.Height = Double.NaN;
            rdgenre.Height = new GridLength(1, GridUnitType.Star);
        }

        private void buttonCatalog_Checked(object sender, RoutedEventArgs e)
        {
            listboxCatalog.Height = 0;
            rdcatalog.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void buttonCatalog_Unchecked(object sender, RoutedEventArgs e)
        {
            listboxCatalog.Height = Double.NaN;
            rdcatalog.Height = new GridLength(1, GridUnitType.Star);
        }

        private void buttonAlbum_Checked(object sender, RoutedEventArgs e)
        {
            listboxAlbum.Height = 0;
            rdalbum.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void buttonAlbum_Unchecked(object sender, RoutedEventArgs e)
        {
            listboxAlbum.Height = Double.NaN;
            rdalbum.Height = new GridLength(1, GridUnitType.Star);
        }
    }
}
