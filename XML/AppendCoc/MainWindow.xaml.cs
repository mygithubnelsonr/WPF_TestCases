using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;

namespace AppendCoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument xmlDoc = new XmlDocument();

        public List<RenameTitle> RenameTitles { get; set; }
        public List<RenameFile> RenamFiles { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists("RenamerLog.xml"))
                NewDocument();

            xmlDoc.Load("RenamerLog.xml");
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            AppendDocument();
        }

        private int NextRenameID()
        {
            int id = 0;
            var renameCount = xmlDoc.DocumentElement.ChildNodes.Count;

            if (renameCount > 0)
            {
                XmlNode nod = xmlDoc.DocumentElement.ChildNodes[renameCount - 1];
                id = Convert.ToInt32(nod.Attributes["id"].Value);
            }

            return id + 1;
        }

        private void AppendDocument()
        {
            List<RenameTitle> titles;
            List<RenameFile> files;

            DateTime dateTime = DateTime.Now;
            string filepath = @"E:\00_mp3\MDx002";
            int id = NextRenameID();

            //XmlDocument xmldoc = new XmlDocument();
            XmlElement elementRoot = xmlDoc.DocumentElement;

            // add rename element
            XmlElement elementRename = xmlDoc.CreateElement(string.Empty, "Rename", string.Empty);
            elementRename.SetAttribute("id", id.ToString());
            elementRoot.AppendChild(elementRename);

            // add element Date
            XmlElement elementDate = xmlDoc.CreateElement(string.Empty, "Date", string.Empty);
            XmlText date = xmlDoc.CreateTextNode(dateTime.Date.ToShortDateString());
            elementDate.AppendChild(date);
            elementRename.AppendChild(elementDate);

            // add element Path
            XmlElement elementPath = xmlDoc.CreateElement(string.Empty, "Path", string.Empty);
            XmlText path = xmlDoc.CreateTextNode(filepath);
            elementPath.AppendChild(path);
            elementRename.AppendChild(elementPath);

            XmlElement elementTitles = xmlDoc.CreateElement(string.Empty, "Titles", string.Empty);
            elementRename.AppendChild(elementTitles);

            titles = LoadTitles();
            foreach (var item in titles)
            {
                XmlElement elementTitle = xmlDoc.CreateElement(string.Empty, "Title", string.Empty);
                elementTitle.SetAttribute("id", item.ID.ToString());
                XmlText text = xmlDoc.CreateTextNode(item.Title);
                elementTitle.AppendChild(text);
                elementTitles.AppendChild(elementTitle);
            }

            files = LoadFiles();
            XmlElement elementFiles = xmlDoc.CreateElement(string.Empty, "Files", string.Empty);
            elementRename.AppendChild(elementFiles);

            foreach (var item in files)
            {
                XmlElement elementFile = xmlDoc.CreateElement(string.Empty, "File", string.Empty);
                elementFile.SetAttribute("id", item.ID.ToString());
                XmlText text = xmlDoc.CreateTextNode(item.Name);
                elementFile.AppendChild(text);
                elementFiles.AppendChild(elementFile);
            }

            xmlDoc.Save("RenamerLog.xml");
        }

        private void NewDocument()
        {
            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //(2) string.Empty makes cleaner code
            XmlElement elementRoot = doc.CreateElement(string.Empty, "log", string.Empty);
            doc.AppendChild(elementRoot);

            doc.Save("RenamerLog.xml");
        }

        private void NewDocumentAll()
        {
            List<RenameTitle> titles;
            List<RenameFile> files;

            DateTime dateTime = DateTime.Now;
            string filepath = @"E:\00_mp3\MDx002";
            int id = 5;

            XmlDocument xmldoc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmldoc.DocumentElement;
            xmldoc.InsertBefore(xmlDeclaration, root);

            //(2) string.Empty makes cleaner code
            XmlElement elementRoot = xmldoc.CreateElement(string.Empty, "log", string.Empty);
            xmldoc.AppendChild(elementRoot);

            // add rename element
            XmlElement elementRename = xmldoc.CreateElement(string.Empty, "rename", string.Empty);
            elementRename.SetAttribute("id", id.ToString());
            elementRoot.AppendChild(elementRename);

            // add element Date
            XmlElement elementDate = xmldoc.CreateElement(string.Empty, "date", string.Empty);
            XmlText date = xmldoc.CreateTextNode(dateTime.Date.ToShortDateString());
            elementDate.AppendChild(date);
            elementRename.AppendChild(elementDate);

            // add element Path
            XmlElement elementPath = xmldoc.CreateElement(string.Empty, "path", string.Empty);
            XmlText path = xmldoc.CreateTextNode(filepath);
            elementPath.AppendChild(path);
            elementRename.AppendChild(elementPath);

            XmlElement elementTitles = xmldoc.CreateElement(string.Empty, "titles", string.Empty);
            elementRename.AppendChild(elementTitles);

            titles = LoadTitles();
            foreach (var item in titles)
            {
                XmlElement elementTitle = xmldoc.CreateElement(string.Empty, "title", string.Empty);
                elementTitle.SetAttribute("id", item.ID.ToString());
                XmlText text = xmldoc.CreateTextNode(item.Title);
                elementTitle.AppendChild(text);
                elementTitles.AppendChild(elementTitle);
            }

            files = LoadFiles();
            XmlElement elementFiles = xmldoc.CreateElement(string.Empty, "files", string.Empty);
            elementRename.AppendChild(elementFiles);

            foreach (var item in files)
            {
                XmlElement elementFile = xmldoc.CreateElement(string.Empty, "file", string.Empty);
                elementFile.SetAttribute("id", item.ID.ToString());
                XmlText text = xmldoc.CreateTextNode(item.Name);
                elementFile.AppendChild(text);
                elementFiles.AppendChild(elementFile);
            }

            xmldoc.Save("document.xml");
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
