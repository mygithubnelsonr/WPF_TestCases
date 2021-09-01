using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorMenu
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

        private void wrappanel1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = e.OriginalSource as Rectangle;
            this.Background = item.Fill;
        }

        private void menuColorStatic_Click(object sender, RoutedEventArgs e)
        {
            wrappanel1.Children.Clear();

            List<SolidColorBrush> colors = new List<SolidColorBrush>();

            ColorList colorList = new ColorList();
            colors = colorList.Load();

            foreach (var color in colors)
            {
                Rectangle rectangle = new Rectangle()
                {
                    Fill = new SolidColorBrush(color.Color),
                    Height = 30,
                    Width = 30,
                    Margin = new Thickness(1),
                    ToolTip = $"{color.Color}"
                };
                wrappanel1.Children.Add(rectangle);
            }
        }

        private void menuColorDynamic_Click(object sender, RoutedEventArgs e)
        {
            wrappanel1.Children.Clear();

            GetColors(0, 0, 255);
            GetColors(0, 255, 255);
            GetColors(0, 255, 0);

            GetColors(255, 0, 255);
            GetColors(255, 0, 0);
            GetColors(255, 255, 0);
        }

        private void buttonWrappanel_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            this.Background = button.Background;
        }

        private void GetColors(int colora, int colorb, int colorc)
        {
            SolidColorBrush color = new SolidColorBrush();

            for (int r = 1; r <= 255; r += 10)
            {
                if (colora == 0)
                {

                    color.Color = Color.FromArgb(0xff, (byte)r, (byte)colorb, (byte)colorc);
                }

                if (colorb == 0)
                    color.Color = Color.FromArgb(0xff, (byte)colora, (byte)r, (byte)colorc);

                if (colorc == 0)
                    color.Color = Color.FromArgb(0xff, (byte)colora, (byte)colorb, (byte)r);

                Rectangle rectangle = new Rectangle()
                {
                    Height = 20,
                    Width = 20,
                    Margin = new Thickness(1),
                    Fill = new SolidColorBrush(color.Color),
                    ToolTip = $"{color.Color}"
                };

                wrappanel1.Children.Add(rectangle);
            }
        }

    }
}
