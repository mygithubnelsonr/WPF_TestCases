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

namespace WpfValidationExample.ValidateWithIDataErrorInfo
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window, INotifyPropertyChanged, IDataErrorInfo
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
                if (_username != value)
                {
                    _username = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _age = 0;

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (_age != value)
                {
                    _age = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Error { get; set; } = "";

        public string this[string propertyName]
        {
            get
            {
                return GetErrorForProperty(propertyName);
            }
        }


        private string GetErrorForProperty(string propertyName)
        {
            Error = "";

            switch (propertyName)
            {
                case "Username":
                    if (_username.Length < 5)
                    {
                        Error = "Username length must be >= 5";
                        return Error;
                    }                    
                    break;
                case "Age":
                    if (_age < 10 || _age > 99)
                    {
                        Error = "Age must be between 10 and 99";
                        return Error;
                    }
                    break;
            }

            return string.Empty;
        }

        public Dialog()
        {
            InitializeComponent();
            this.DataContext = this;
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
            if (this.DialogResult == true)
            {
                if (!string.IsNullOrEmpty(Error))
                {
                    MessageBox.Show("Please correct the input first.");
                    e.Cancel = true;
                }
            }
        }
    }
}
