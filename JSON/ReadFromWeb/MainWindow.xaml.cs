using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace ReadFromWeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _uri = "http://bobandsonja.de/";
        private string _file = "plants.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonRead_Click(object sender, RoutedEventArgs e)
        {
            JsonRead();
        }

        private void buttonWrite_Click(object sender, RoutedEventArgs e)
        {
            JsonWrite();
        }

        private void JsonRead()
        {
            WebClient webClient = new WebClient();
            string address = _uri + _file;

            var jsonData = webClient.DownloadString(address);
            textbox1.Text = jsonData;

            File.WriteAllText("plants.json", jsonData);

        }

        private void JsonWrite()
        {
            WebClient webClient = new WebClient();

            File.WriteAllText("plants.json", textbox1.Text);

            var result = webClient.UploadFile(_uri, "POST", _file);

            Debug.Print(result.ToString());

        }
    }
}
