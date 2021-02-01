using Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CRUD_Examples
{
    enum State
    {
        Normal,
        Edit,
        New,
        Delete
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<Person> personList = new ObservableCollection<Person>();
        private string _fileName = "persons.json";
        private State State = State.Normal;

        public MainWindow()
        {
            InitializeComponent();
            Fill();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            // warning message

            State = State.Delete;

            int index = listBox.SelectedIndex;
            personList.RemoveAt(index);

            index--;
            listBox.SelectedIndex = index;
            listBox.Focus();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            State = State.Edit;

            int index = listBox.SelectedIndex;

            textVorname.IsEnabled = true;
            textNachname.IsEnabled = true;
            textAlter.IsEnabled = true;
            textImage.IsEnabled = true;
            textImage.Text = personList[index].Image;
            picture.Visibility = Visibility.Hidden;
            textImage.Visibility = Visibility.Visible;
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            State = State.New;
            //this.DataContext = null;

            int id = personList.Max(p => p.ID);
            int newId = id + 1;

            personList.Add(new Person() { ID = newId });

            this.DataContext = personList[id];

            listBox.SelectedItem = listBox.Items.Count;

            //textID.Text = $"{newId}";
            textVorname.Text = ""; textVorname.IsEnabled = true;
            textNachname.Text = ""; textNachname.IsEnabled = true;
            textAlter.Text = ""; textAlter.IsEnabled = true;
            textImage.Text = ""; textImage.IsEnabled = true;
            picture.Visibility = Visibility.Hidden;
            textImage.Visibility = Visibility.Visible;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Write();

            State = State.Normal;

            picture.Visibility = Visibility.Visible;
            textImage.Visibility = Visibility.Hidden;

            listBox.Focus();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listBox.Items.Count <= 0 || listBox.SelectedIndex == -1)
                return;

            //var x = listBox.Items.Count;
            //Debug.Print(x.ToString());

            picture.Visibility = Visibility.Visible;
            textImage.Visibility = Visibility.Hidden;

            int index = listBox.SelectedIndex;
            this.DataContext = personList[index];

            string img = personList[index].Image;

            Uri uri;
            BitmapImage image;     // = new BitmapImage();
            uri = new Uri(@"..\Images\" + img, UriKind.Relative);
            image = new BitmapImage(uri);   // new Uri($"Images/Avatar05.png", UriKind.RelativeOrAbsolute);
            picture.Source = image;
            picture.Stretch = System.Windows.Media.Stretch.Uniform;

        }

        private void Write()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            //serializer.Converters.Add(new JavaScriptDateTimeConverter());
            //serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(_fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, personList);
            }
        }

        private void Fill()
        {
            if (!File.Exists(_fileName))
                return;

            var jsonData = File.ReadAllText(_fileName);
            personList = JsonConvert.DeserializeObject<ObservableCollection<Person>>(jsonData);

            listBox.ItemsSource = personList;
            listBox.Focus();
        }
    }
}
