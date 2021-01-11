using System.Collections.Generic;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Model;

namespace WpfTestCases
{
    /// <summary>
    /// Interaction logic for Datenvorlagen.xaml
    /// </summary>
    public partial class Datenvorlagen : Window
    {
        List<Person> personList;
        private string _fileName = "Persons.xml";

        public Datenvorlagen()
        {
            InitializeComponent();

            // fill person list
            personList = new List<Person>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (XmlReader xmlReader = XmlReader.Create(_fileName))
                personList = (List<Person>)serializer.Deserialize(xmlReader);

            lstPersons.ItemsSource = personList;
            lstPersons.SelectedIndex = 0;
            lstPersons.SelectedItem = 0;
            lstPersons.Focus();
        }

        private void lstPersons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Person person = lstPersons.SelectedItem as Person;
            txtInfo.Text = $"ID:{person.ID} | Vorname:{person.Vorname} | Nachname:{person.Nachname} | Alter:{person.Alter}";
        }
    }
}
