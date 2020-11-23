using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace RenameLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ImportDate> _imports;

        string _rawJSON;
        public string RawJSON { get => _rawJSON; set => _rawJSON = value; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {

            List<ImportDate> _imports = new List<ImportDate>();

            List<Title> titles = new List<Title>();
            titles.Add(new Title() { _Id = "01", _Title = "qwreqweq" });

            List<File> files = new List<File>();
            files.Add(new File() { _Id = "01", _File = "asdasda" });

            _imports.Add(new ImportDate { titles = titles, files = files });

            var result = JsonConvert.SerializeObject(_imports, Formatting.Indented);
            Debug.Print($"{result}");

            //System.IO.File.WriteAllText($"Students/{this.Name}.json", jsonData);

            textblockLeft.Text = result;

        }
    }
}
