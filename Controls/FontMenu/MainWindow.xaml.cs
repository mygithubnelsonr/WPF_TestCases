using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FontMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _fontSize = 14;
        private FontFamily _fontName = new FontFamily("Arial");

        public MainWindow()
        {
            InitializeComponent();

            MenuFillSize();

            MenuFillFonts();

        }

        private void menuSize_Click(object sender, RoutedEventArgs e)
        {
            var menuitem = sender as MenuItem;
            _fontSize = Convert.ToInt32(menuitem.Header);

            textblock.FontSize = _fontSize;
            textblock.FontFamily = _fontName;
            textblock.Text = $"{_fontName} => {_fontSize}";
        }

        private void menuFont_Click(object sender, RoutedEventArgs e)
        {
            var menuitem = sender as MenuItem;
            _fontName = new FontFamily(menuitem.Header.ToString());

            textblock.FontSize = _fontSize;
            textblock.FontFamily = _fontName;
            textblock.Text = $"{_fontName} => {_fontSize}";
        }

        private void MenuFillSize()
        {
            int[] sizes = { 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 36, 48, 72 };

            foreach (int s in sizes)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = s.ToString();
                menuItem.Click += new RoutedEventHandler(this.menuSize_Click);
                menuSize.Items.Add(menuItem);
            }
        }

        private void MenuFillFonts()
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = fontFamily.Source;
                menuItem.Click += new RoutedEventHandler(this.menuFont_Click);
                menuFont.Items.Add(menuItem);
            }
        }

    }
}
