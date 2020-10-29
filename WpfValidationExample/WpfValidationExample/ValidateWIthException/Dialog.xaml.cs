using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfValidationExample.ValidateWIthException
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window, INotifyPropertyChanged
    {
        private string _username = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                ValidateUserName(value);
                _username = value;
                NotifyPropertyChanged();
            }
        }

        private static void ValidateUserName(string value)
        {
            if (value.Length < 5)
            {
                //throw new ArgumentException("Username must be length > 5.");
            }
        }

        public Dialog()
        {
            InitializeComponent();
            this.DataContext = this;
            TextBoxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == true)
            {
                try
                {                    
                    ValidateUserName(_username);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;                   
                }
            }
        }
    }
}
