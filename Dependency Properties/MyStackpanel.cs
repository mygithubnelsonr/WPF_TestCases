using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dependency_Properties
{
    public class MyStackpanel : StackPanel
    {
        public static readonly DependencyProperty IsBlueProperty =
            DependencyProperty.Register("IsBlue", typeof(bool), typeof(MyStackpanel),
                new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsBluePropertyChanged)));

        public bool IsBlue
        {
            // GetValue is avaiable because Stackpanel
            get { return (bool)GetValue(IsBlueProperty); }
            set { SetValue(IsBlueProperty, value); }
        }

        static void IsBluePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            MyStackpanel myStackpanel = sender as MyStackpanel;

            if (myStackpanel.IsBlue == true)
                myStackpanel.Background = new SolidColorBrush(Colors.Blue);
            else
                myStackpanel.Background = new SolidColorBrush(Colors.White);
        }
    }
}
