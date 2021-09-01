using System.Collections.Generic;
using System.Windows.Media;

namespace ColorMenu
{
    public class ColorList
    {
        List<SolidColorBrush> colors;

        public ColorList() { }

        public List<SolidColorBrush> Load()
        {
            colors = new List<SolidColorBrush>
            {
                Brushes.Black, Brushes.Brown, Brushes.DarkGreen, Brushes.MidnightBlue,
                Brushes.Navy, Brushes.DarkBlue, Brushes.Indigo, Brushes.DimGray,

                Brushes.DarkRed, Brushes.OrangeRed, Brushes.Olive, Brushes.Green,
                Brushes.Teal, Brushes.Blue, Brushes.SlateGray, Brushes.Gray,

                Brushes.Red, Brushes.Orange, Brushes.YellowGreen, Brushes.SeaGreen,
                Brushes.Aqua, Brushes.LightBlue, Brushes.Violet, Brushes.DarkGray,

                Brushes.Pink, Brushes.Gold, Brushes.Yellow, Brushes.Lime,
                Brushes.Turquoise, Brushes.SkyBlue, Brushes.Plum, Brushes.LightGray ,

                Brushes.LightPink, Brushes.Tan, Brushes.LightYellow, Brushes.LightGreen,
                Brushes.LightCyan, Brushes.LightSkyBlue, Brushes.Lavender, Brushes.White
            };

            return colors;
        }
    }
}
