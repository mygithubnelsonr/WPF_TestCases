using Entity;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Combobox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //  #error version

    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> PersonList;
        private ObservableCollection<Query> QueryList;
        private int counter = 0;

        public MainWindow()
        {
            InitializeComponent();

            PersonList people = new PersonList();
            var listp = people.Load();
            PersonList = new ObservableCollection<Person>(listp);

            QueryList queries = new QueryList();
            var listq = queries.Load();
            QueryList = new ObservableCollection<Query>(listq);

            combobox.ItemsSource = QueryList;
            combobox.SelectedIndex = 0;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            counter = combobox.SelectedIndex;

            if (combobox.ItemsSource.ToString().IndexOf("Query") > 0)
            {
                Query query = combobox.SelectedItem as Query;
                if (query.ID == 0)
                {
                    textblock.Text = "";
                    labelPerson.Content = "";
                }
                else
                {
                    textblock.Text = $"ID: {query.ID}";
                    labelPerson.Content = $"Name: {query.Name}\nRow: {query.Row}";
                }
            }

            if (combobox.ItemsSource.ToString().IndexOf("Person") > 0)
            {
                Person person = combobox.SelectedItem as Person;
                if (person.ID == 0)
                {
                    textblock.Text = "";
                    labelPerson.Content = "";
                }
                else
                {
                    textblock.Text = $"ID: {person.ID}";
                    labelPerson.Content = $"Name: {person.Name}\n{person.Vorname}\nAlter: {person.Alter}";
                }
            }

        }

        private void buttonDown_Click(object sender, RoutedEventArgs e)
        {
            if (counter < combobox.Items.Count)
            {
                counter++;
                combobox.SelectedIndex = counter;
            }
        }

        private void buttonUp_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                combobox.SelectedIndex = counter;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = PersonList.Max(p => p.ID);
            Person person = new Person() { ID = id + 1, Name = "Kraut", Vorname = "Holger", Alter = 28 };
            PersonList.Add(person);
        }

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
