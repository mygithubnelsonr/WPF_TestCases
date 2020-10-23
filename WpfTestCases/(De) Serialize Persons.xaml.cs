using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace WpfTestCases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> personList;
        private string _fileName = "Persons.xml";

        public MainWindow()
        {
            InitializeComponent();

            personList = new List<Person>();

            // Person befüllen
            //personList.AddRange(new Person[] {
            //    new Person(1, "Bob", "Nelson", 65, "image/avatar05"),
            //    new Person(2, "Sepp", "Meier", 23, "image/avatar06"),
            //    new Person(3, "Anna", "Huber", 21, "image/avatar07")
            //});

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            using (XmlReader xmlReader = XmlReader.Create(_fileName))
            {
                personList = (List<Person>)serializer.Deserialize(xmlReader);
            }

            foreach (var p in personList)
            {
                listBox.Items.Add($"{p.ID} | {p.Vorname} | {p.Nachname} | {p.Alter} | {p.Image}");
            }
        }

        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {
            ButtonGo();
        }

        public void ButtonGo()
        {
            try
            {
                var id = System.Convert.ToInt32(textID.Text);
                var vn = textVorname.Text;
                var nn = textNachname.Text;
                var alter = System.Convert.ToInt32(textAlter.Text);
                var im = textImage.Text;

                personList.Add(new Person(id, vn, nn, alter, im));

                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

                using (XmlWriter xmlWriter = XmlWriter.Create(_fileName))
                {
                    serializer.Serialize(xmlWriter, personList);
                }

                listBox.Items.Add($"{id} | {vn} | {nn} | {alter} | {im}");

            }
            catch (Exception e)
            {
                MessageBox.Show("Error! " + e.Message);
            }
        }

    }
}
