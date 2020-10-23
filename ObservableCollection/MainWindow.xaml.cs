using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> personList = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();

            personList.Add(new Person(1, "Nelson", "Bob", 65));
            personList.Add(new Person(2, "Meier", "Sepp", 23));
            personList.Add(new Person(3, "Huber", "Anna", 21));

            listboxPersons.ItemsSource = personList;
        }

        private void listboxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = listboxPersons.SelectedItem as Person;
            labelPerson.Content = $"ID: {person.ID}\nName: {person.Vorname} {person.Name}, Alter: {person.Alter}";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            personList.Add(new Person(4, "Gruber", "Josef", 34));
        }
    }
}
