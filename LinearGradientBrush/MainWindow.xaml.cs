using System.Windows;
using System.Windows.Media;

namespace LinearGradientBrush
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

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            ra3.GradientStops.Clear();
            ra3.GradientStops.Add(new GradientStop(Colors.Black, 0.0));
            ra3.GradientStops.Add(new GradientStop(Colors.DarkBlue, 0.2));
            ra3.GradientStops.Add(new GradientStop(Colors.Blue, 0.35));
            ra3.GradientStops.Add(new GradientStop(Colors.Red, 0.5));
            ra3.GradientStops.Add(new GradientStop(Colors.Orange, 0.65));
            ra3.GradientStops.Add(new GradientStop(Colors.Yellow, 0.9));
            ra3.GradientStops.Add(new GradientStop(Colors.White, 1.0));

            //< GradientStop Color = "#FF2C0202" Offset = "0" />
            //< GradientStop Color = "Red" Offset = "0.2" />
            //< GradientStop Color = "#FFFF6209" Offset = "0.35" />
            //< GradientStop Color = "#FFEAB832" Offset = "0.5" />
            //< GradientStop Color = "Yellow" Offset = "0.65" />
            //< GradientStop Color = "LightYellow" Offset = "0.9" />
            //< GradientStop Color = "White" Offset = "1" />
        }
    }
}
