using System;
using System.Windows;
using System.Windows.Threading;

namespace Temp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timerEditor;

        public static bool processEnded = false;

        public MainWindow()
        {
            InitializeComponent();

            timerEditor = new DispatcherTimer();
            timerEditor.Interval = TimeSpan.FromSeconds(1);
            timerEditor.Tick += timerEditor_Tick;
            timerEditor.IsEnabled = true;
            timerEditor.Stop();
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {

            int id = 1000;
            Start_Notepad start_Notepad = new Start_Notepad();
            start_Notepad.DefineProcess(id.ToString());

            timerEditor.Start();

        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Meldung()
        {
            MessageBox.Show("Editor process endet");
        }

        private void timerEditor_Tick(object sender, EventArgs e)
        {
            if (processEnded == true)
            {
                Meldung();
                timerEditor.Stop();
            }
        }
    }
}
