using System.Windows;

namespace Custom_Input
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string PlaceholderText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonDialogOk_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
