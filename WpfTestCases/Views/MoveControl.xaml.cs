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
using System.Windows.Shapes;

namespace WpfTestCases
{
    /// <summary>
    /// Interaction logic for MoveControl.xaml
    /// </summary>
    public partial class MoveControl : Window
    {
        public MoveControl()
        {
            InitializeComponent();
        }

        private void gridmovetext_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.Print("gridmovetext_MouseMove");
            fp_Move_Control(sender, e);
        }

        private void textblock_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.Print("textblock_MouseMove");
            Mouse.OverrideCursor = Cursors.Hand;
            fp_Move_Control(sender, e);
            e.Handled = true;
        }

        private void fp_Move_Control(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (Mouse.OverrideCursor == Cursors.Hand)
                {
                    TextBlock textBlock = textblock;
                    if (textBlock != null)
                    {
                        // move the control
                        Point mousePoint = e.GetPosition(this);

                        // vertical
                        int posY = (int)mousePoint.Y;
                        int actHeight = (int)Application.Current.MainWindow.Height;
                        int marginBottom = actHeight - (posY + (int)textBlock.Height +
                        (int)SystemParameters.CaptionHeight + (int)SystemParameters.BorderWidth);

                        // horizontal
                        int posX = (int)mousePoint.X;
                        int actWidth = (int)Application.Current.MainWindow.Width;
                        int marginRight = actWidth - (posX + (int)textBlock.Width +
                        (int)SystemParameters.BorderWidth);

                        // move object
                        textBlock.Margin = new Thickness(posX, posY, marginRight, marginBottom);
                        Mouse.OverrideCursor = Cursors.Hand;
                    }
                }
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

    }
}
