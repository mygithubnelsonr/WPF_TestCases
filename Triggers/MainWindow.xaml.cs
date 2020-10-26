using System.Windows;

namespace Triggers
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

        private void ButtonPropertyTrigger_Click(object sender, RoutedEventArgs e)
        {
            PropertyTrigger.Dialog dialog = new PropertyTrigger.Dialog();
            dialog.Owner = this;
            dialog.ShowDialog();
        }

        private void ButtonDataTriggers_Click(object sender, RoutedEventArgs e)
        {
            DataTriggers.Dialog dialog = new DataTriggers.Dialog();
            dialog.Owner = this;
            dialog.ShowDialog();
        }

        private void ButtonEventTriggers_Click(object sender, RoutedEventArgs e)
        {
            EventTriggers.Dialog dialog = new EventTriggers.Dialog();
            dialog.Owner = this;
            dialog.ShowDialog();
        }
    }
}
