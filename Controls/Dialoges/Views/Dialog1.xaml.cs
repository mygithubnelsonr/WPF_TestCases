using System.Collections.Generic;
using System.Windows;
using Dialoges.DataAccess;
using Dialoges.Entities;

namespace Dialoges
{
    /// <summary>
    /// Interaction logic for Dialog1.xaml
    /// </summary>
    public partial class Dialog1 : Window
    {
        public string Firstname { get; set; }
        public List<Person> People { get; set; }

        public Dialog1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            People = DataLoader.LoadPersons();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Firstname = textFirstname.Text;
            this.DialogResult = true;
        }
    }
}
