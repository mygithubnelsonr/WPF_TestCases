﻿using System.Windows.Media.Imaging;

namespace Listbox_mit_Grafik
{
    public class Sitcom
    {
        public string Name { get; set; }
        public int StartYear { get; set; }
        public bool IsStudioSitcom { get; set; }
        public BitmapSource Image { get; set; }
    }
}
