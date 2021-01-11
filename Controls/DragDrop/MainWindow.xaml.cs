using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace DragDrop
{
    /// <summary>
    /// move mp3 files to folder Collection
    /// </summary>
    public partial class MainWindow : Window
    {
        private string targetFolder = "Collection";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewDragEnter(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void Window_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void Window_PreviewDrop(object sender, DragEventArgs e)
        {
            string fullpath = "";

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.Background = Brushes.LightSalmon;

                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (var filename in filenames)
                {
                    fullpath = filename;

                    bool isFolder = File.GetAttributes(fullpath).HasFlag(FileAttributes.Directory);

                    if (isFolder == true)
                    {
                        ProcessFolder(fullpath, ".mp3");
                    }
                }

                this.Activate();
            }
            this.Background = Brushes.LightSkyBlue;

            MessageBox.Show("Fertig");
        }

        private void ProcessFolder(string fullpath, string extension)
        {

            if (!FileTypeExist(fullpath, extension))
                return;

            bool result = CreateTargetFolder(fullpath);

            if (result)
            {
                DirectoryInfo di = new DirectoryInfo(fullpath);

                FileInfo[] fileInfos = di.GetFiles($"*{extension}");

                foreach (var fileInfo in fileInfos)
                {
                    string path = fileInfo.DirectoryName;
                    string file = fileInfo.Name;

                    Debug.Print($" to {Path.Combine(path, targetFolder, file)}");
                    Debug.Print($"move {fileInfo.FullName}");

                    File.Move(fileInfo.FullName, Path.Combine(path, targetFolder, file));
                }
            }
        }

        private bool FileTypeExist(string fullpath, string extension)
        {
            DirectoryInfo di = new DirectoryInfo(fullpath);

            FileInfo[] fileInfos = di.GetFiles($"*{extension}");

            return fileInfos.Length > 0;
        }

        private bool CreateTargetFolder(string fullpath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(Path.Combine(fullpath, targetFolder));

                if (!di.Exists)
                {
                    di.Create();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
