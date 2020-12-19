using NewDoc.Entitie;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;

namespace NewDoc
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
            List<RenameTitle> titles = new List<RenameTitle>();
            List<RenameFile> files;

            DateTime dateTime = DateTime.Now;
            string filepath = @"E:\00_mp3\MDx002";
            int id = 5;

            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //(2) string.Empty makes cleaner code
            XmlElement elementRoot = doc.CreateElement(string.Empty, "log", string.Empty);
            doc.AppendChild(elementRoot);

            // add rename element
            XmlElement elementRename = doc.CreateElement(string.Empty, "rename", string.Empty);
            elementRename.SetAttribute("id", id.ToString());
            elementRoot.AppendChild(elementRename);

            // add element Date
            XmlElement elementDate = doc.CreateElement(string.Empty, "date", string.Empty);
            XmlText date = doc.CreateTextNode(dateTime.Date.ToShortDateString());
            elementDate.AppendChild(date);
            elementRename.AppendChild(elementDate);

            // add element Path
            XmlElement elementPath = doc.CreateElement(string.Empty, "path", string.Empty);
            XmlText path = doc.CreateTextNode(filepath);
            elementPath.AppendChild(path);
            elementRename.AppendChild(elementPath);

            XmlElement elementTitles = doc.CreateElement(string.Empty, "titles", string.Empty);
            elementRename.AppendChild(elementTitles);

            titles = LoadTitles();
            foreach (var item in titles)
            {
                XmlElement elementTitle = doc.CreateElement(string.Empty, "title", string.Empty);
                elementTitle.SetAttribute("id", item.ID.ToString());
                XmlText text = doc.CreateTextNode(item.Title);
                elementTitle.AppendChild(text);
                elementTitles.AppendChild(elementTitle);
            }

            files = LoadFiles();
            XmlElement elementFiles = doc.CreateElement(string.Empty, "files", string.Empty);
            elementRename.AppendChild(elementFiles);

            foreach (var item in files)
            {
                XmlElement elementFile = doc.CreateElement(string.Empty, "file", string.Empty);
                elementFile.SetAttribute("id", item.ID.ToString());
                XmlText text = doc.CreateTextNode(item.Name);
                elementFile.AppendChild(text);
                elementFiles.AppendChild(elementFile);
            }

            doc.Save("document.xml");
        }

        private List<RenameTitle> LoadTitles()
        {
            List<RenameTitle> renameTitles = new List<RenameTitle>();

            renameTitles.Add(new RenameTitle()
            { ID = 1, Title = "tony carey - we wanna live" });
            renameTitles.Add(new RenameTitle()
            { ID = 2, Title = "tony carey -she moves like a dancer" });
            renameTitles.Add(new RenameTitle()
            { ID = 3, Title = "tony carey -live wire" });
            renameTitles.Add(new RenameTitle()
            { ID = 4, Title = "tony carey - 10.000 times" });
            renameTitles.Add(new RenameTitle()
            { ID = 5, Title = "tony carey - tear down the walls" });
            renameTitles.Add(new RenameTitle()
            { ID = 6, Title = "tony carey - blue highway" });
            renameTitles.Add(new RenameTitle()
            { ID = 7, Title = "tony carey - love don't bother me" });
            renameTitles.Add(new RenameTitle()
            { ID = 8, Title = "tony carey -katy be mine" });
            renameTitles.Add(new RenameTitle()
            { ID = 9, Title = "reba mcentire -like a rock" });
            renameTitles.Add(new RenameTitle()
            { ID = 10, Title = "tony carey - out of town woman" });
            renameTitles.Add(new RenameTitle()
            { ID = 11, Title = "tony carey - oux of xown womanx" });

            return renameTitles;
        }

        private List<RenameFile> LoadFiles()
        {
            List<RenameFile> renameFiles = new List<RenameFile>();

            renameFiles.Add(new RenameFile
            { ID = 1, Name = "Track - 01.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 2, Name = "Track - 02.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 3, Name = "Track - 03.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 4, Name = "Track - 04.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 5, Name = "Track - 05.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 6, Name = "Track - 07.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 7, Name = "Track - 08.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 8, Name = "Track - 09.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 9, Name = "Track - 10.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 10, Name = "Track - 11.mp3" });
            renameFiles.Add(new RenameFile
            { ID = 11, Name = "Track - 12.mp3" });

            return renameFiles;
        }
    }
}
