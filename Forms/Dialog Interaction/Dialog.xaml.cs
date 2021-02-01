using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dialog_Interaction
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        Window main;

        public Dialog(Window w)
        {
            InitializeComponent();
            main = w;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            ((MainWindow)main).OnDialogButtonClicked(button);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)main).OnDialogEnded();
        }

        private void textbox_KeyUp(object sender, KeyEventArgs e)
        {
            ((MainWindow)main).OnDialogTextChanged(textbox.Text);
        }
    }
}
