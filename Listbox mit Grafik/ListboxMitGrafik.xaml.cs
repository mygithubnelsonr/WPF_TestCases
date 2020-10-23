using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Listbox_mit_Grafik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Sitcom> sitcoms;

        public MainWindow()
        {
            InitializeComponent();

            sitcoms = GetSitcoms();

            lstSitcoms1.ItemsSource = sitcoms;
        }

        public ObservableCollection<Sitcom> GetSitcoms()
        {
            // Ergebnis-Auflistung erzeugen
            ObservableCollection<Sitcom> sitcoms = new ObservableCollection<Sitcom>();

            // Sitcoms mit deren Darstellern erzeugen
            sitcoms.Add(new Sitcom
            {
                Name = "My Name Is Earl",
                StartYear = 2005,
                IsStudioSitcom = false,
                Image = BitmapFrame.Create(
                    new Uri("Images/Avatar05.png", UriKind.Relative))
            });

            sitcoms.Add(new Sitcom
            {
                Name = "The Big Bang Theory",
                StartYear = 2007,
                IsStudioSitcom = true,
                Image = BitmapFrame.Create(
                    new Uri("Images/Avatar06.png", UriKind.Relative))
            });

            sitcoms.Add(new Sitcom
            {
                Name = "Scrubs ",
                StartYear = 2001,
                IsStudioSitcom = true,
                Image = BitmapFrame.Create(
                    new Uri("Images/Avatar07.png", UriKind.Relative))
            });

            return sitcoms; // Das Ergebnis zurückgeben
        }
    }
}
