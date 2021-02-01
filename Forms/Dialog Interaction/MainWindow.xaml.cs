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

namespace Dialog_Interaction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // declaring an event using built-in EventHandler
        public event EventHandler DialogEnded;
        public event EventHandler DialogTextChanged;
        public event EventHandler DialogButtonClicked;

        public string TextblockContent
        {
            get { return textblock.Text; }
            set { textblock.Text = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOperDialog_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialog = new Dialog(this);
            dialog.Owner = this;
            dialog.ShowDialog();
            dialog.Close();
        }

        public void OnDialogEnded()
        {
            textblock.Text = "Dialog ended";
        }

        public void OnDialogTextChanged(string message)
        {
            textblock.Text = message;
        }

        public void OnDialogButtonClicked(Button button)
        {
            textblock.Text = $"Button {button.Name} clicked";
        }
    }
}
