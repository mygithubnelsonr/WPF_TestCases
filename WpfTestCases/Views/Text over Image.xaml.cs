using System.Windows;

//
// https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwj9iZbCyuvrAhUOMewKHb8-BsUQwqsBMAV6BAgMEAU&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D8DwJ_3EPJAI&usg=AOvVaw3IgqR0gQ1-C5Tq70KGxlgL
//
namespace WpfTestCases
{
    /// <summary>
    /// Interaction logic for Text_over_Image.xaml
    /// </summary>
    public partial class Text_over_Image : Window
    {
        public Text_over_Image()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonmove1_Click(object sender, RoutedEventArgs e)
        {
            textblock.Margin = new Thickness(0, 0, 0, 0);
        }

        private void ButtonMove2_Click(object sender, RoutedEventArgs e)
        {
            textblock.Margin = new Thickness(40, 20, 0, 0);
        }

        private void buttonmove3_Click(object sender, RoutedEventArgs e)
        {
            textblock.Margin = new Thickness(80, 40, 0, 0);
        }

        private void ButtonMove4_Click(object sender, RoutedEventArgs e)
        {
            textblock.Margin = new Thickness(120, 60, 0, 0);
        }

        private void ButtonMove5_Click(object sender, RoutedEventArgs e)
        {
            textblock.Margin = new Thickness(160, 80, 0, 0);
        }
    }
}
