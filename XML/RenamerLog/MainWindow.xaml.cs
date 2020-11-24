using RenamerLog.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace RenamerLog
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

        private void openDialog_Click(object sender, RoutedEventArgs e)
        {
            List<RenameTitle> listTitles = new List<RenameTitle>();
            List<RenameFile> listFiles = new List<RenameFile>();

            Renames renames = new Renames();
            renames.ShowDialog();

            if (renames.DialogResult == true)
            {
                listTitles = renames.RenameTitles;
                if (listTitles != null)
                {
                    Debug.Print($"{listTitles.Count}");
                    foreach( var t in listTitles)
                    {
                        Debug.Print($"{t.ID.ToString("00")}, {t.Title}");
                    }
                }

                listFiles = renames.RenamFiles;
                if(listFiles != null)
                { 
                    Debug.Print($"{listFiles.Count}");
                    foreach( var f in listFiles)
                    {
                        Debug.Print($"{f.ID.ToString("00")}, {f.Name}");
                    }
                }
            }
            renames.Close();
        }
    }
}
