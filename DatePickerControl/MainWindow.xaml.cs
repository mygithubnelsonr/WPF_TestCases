using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DatePickerControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime StartDateTime;
        public DateTime NewDateTime;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartDateTime = new DateTime(2006,8,5,18,12,12);
            startDate.Text = StartDateTime.Date.ToShortDateString();
            starttime.Text = StartDateTime.ToShortTimeString() + ":01";
            datepicker.SelectedDate = StartDateTime.Date;
        }

        private void CommandClose_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandSave_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = startDate.Text != "" && starttime.Text != "";
        }

        private void CommandSave_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            string datetime = startDate.Text + " " + starttime.Text;
            DateTime dt = DateTime.Parse(datetime);
            NewDateTime = dt;
            this.Close();
        }

        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = sender as DatePicker;
            Debug.Print($"{date}");

            DateTime dt = new DateTime();
            dt = (DateTime)date.SelectedDate;
            startDate.Text = dt.Date.ToShortDateString();
        }
    }
}
