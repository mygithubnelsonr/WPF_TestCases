using System;
using System.Collections.Generic;
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
using System.Xml;
using System.Xml.Serialization;
using Model;

namespace _De__Serialize
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

            // Person mit AddRange befüllen
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

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            int id = personList.Max(p => p.ID);

            textID.Text = $"{id + 1}";
            textVorname.Text = ""; textVorname.IsEnabled = true;
            textNachname.Text = ""; textNachname.IsEnabled = true;
            textAlter.Text = ""; textAlter.IsEnabled = true;
            textImage.Text = ""; textImage.IsEnabled = true;
            picture.Visibility = Visibility.Hidden;
            textImage.Visibility = Visibility.Visible;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            PersonAdd();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            picture.Visibility = Visibility.Visible;
            textImage.Visibility = Visibility.Hidden;

            int index = listBox.SelectedIndex;
            textID.Text = $"{personList[index].ID}";
            textVorname.Text = $"{personList[index].Vorname}";
            textNachname.Text = $"{personList[index].Vorname}";
            textAlter.Text = $"{personList[index].Alter}";
            string img = personList[index].Image;

            Uri uri;
            BitmapImage image;     // = new BitmapImage();
            uri = new Uri(@"..\" + img, UriKind.Relative);
            image = new BitmapImage(uri);   // new Uri($"Images/Avatar05.png", UriKind.RelativeOrAbsolute);
            picture.Source = image;
            picture.Stretch = System.Windows.Media.Stretch.Uniform;
        }

        public void PersonAdd()
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

                textVorname.IsEnabled = false;
                textNachname.IsEnabled = false;
                textAlter.IsEnabled = false;
                textImage.IsEnabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error! " + e.Message);
            }
        }
    }
}
