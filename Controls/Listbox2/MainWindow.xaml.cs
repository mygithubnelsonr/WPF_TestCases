using System;
using System.Windows;

namespace Listbox2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _formLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void expanderGenre_Expanded(object sender, RoutedEventArgs e)
        {
            if (!_formLoaded) return;

            listboxGenre.Height = Double.NaN;
            rdgenre.Height = new GridLength(1, GridUnitType.Star);
        }

        private void expanderGenre_Collapsed(object sender, RoutedEventArgs e)
        {
            listboxGenre.Height = 0;
            rdgenre.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void expanderCatalog_Expanded(object sender, RoutedEventArgs e)
        {
            if (!_formLoaded) return;

            listboxCatalog.Height = Double.NaN;
            rdcatalog.Height = new GridLength(1, GridUnitType.Star);
        }

        private void expanderCatalog_Collapsed(object sender, RoutedEventArgs e)
        {
            listboxCatalog.Height = 0;
            rdcatalog.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void expanderAlbum_Expanded(object sender, RoutedEventArgs e)
        {
            if (!_formLoaded) return;

            listboxAlbum.Height = Double.NaN;
            rdalbum.Height = new GridLength(1, GridUnitType.Star);
        }

        private void expanderAlbum_Collapsed(object sender, RoutedEventArgs e)
        {
            listboxAlbum.Height = 0;
            rdalbum.Height = new GridLength(1, GridUnitType.Auto);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _formLoaded = true;
        }
    }
}
