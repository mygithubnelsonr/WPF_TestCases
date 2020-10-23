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


namespace WpfValidationExample
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

        private void ButtonValidationWithException_Click(object sender, RoutedEventArgs e)
        {
            ValidateWIthException.Dialog dlg = new ValidateWIthException.Dialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }

        private void ButtonValidationIDataErrorInfo_Click(object sender, RoutedEventArgs e)
        {
            ValidateWithIDataErrorInfo.Dialog dlg = new ValidateWithIDataErrorInfo.Dialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }

        private void ButtonValidationRule_Click(object sender, RoutedEventArgs e)
        {
            ValidateWithValidationRule.Dialog dlg = new ValidateWithValidationRule.Dialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }
    }
}
