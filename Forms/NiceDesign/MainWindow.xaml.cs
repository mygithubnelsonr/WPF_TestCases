using System.Windows;
using System.Windows.Input;

namespace NiceDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
