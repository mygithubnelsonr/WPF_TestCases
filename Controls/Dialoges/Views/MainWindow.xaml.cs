using Dialoges.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Dialoges
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

        private void buttonDialog_Click(object sender, RoutedEventArgs e)
        {
            List<Person> names = new List<Person>();

            Dialog1 dialog = new Dialog1();
            dialog.textFirstname.Focus();
            bool? isSaved = dialog.ShowDialog();
            if (isSaved == true)
            {
                textblockName.Text = dialog.Firstname;
                names = dialog.People;
            }
            dialog.Close();

            Debug.Print($"PersonCount: {names.Count}");
            foreach (var p in names)
            {
                Debug.Print($"{p.ID}, {p.Vorname}, {p.Nachame}");
            }
        }
    }
}
