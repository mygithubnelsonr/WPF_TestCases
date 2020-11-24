using RenamerLog.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Xml;

namespace RenamerLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Renames : Window
    {
        private XmlDocument xmlDoc = new XmlDocument();

        public List<RenameTitle> RenameTitles { get; set; }
        public List<RenameFile> RenamFiles { get; set; }

        public Renames()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xmlDoc.Load("RenamerLog.xml");
            FillRenameDates();
        }

        private void listboxDates_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RenameDate item = (RenameDate)listboxDates.SelectedItem;
            var id = item.ID;
            FillRenameTitles(id);
            FillRenameFiles(id);
        }

        private void UseReader()
        {
            List<RenameDate> renames = new List<RenameDate>();
            StringBuilder xml = new StringBuilder();
            XmlReader xmlReader = XmlReader.Create("RenamerLog.xml");

            string id = "";
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Rename"))
                {
                    if (!String.IsNullOrEmpty(xmlReader.GetAttribute("id")))
                    {
                        id = xmlReader.GetAttribute("id");
                        int _id = Convert.ToInt32(id);
                        renames.Add(new RenameDate() { ID = _id });
                    }
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Date"))
                {
                    string date = xmlReader.ReadElementContentAsString();
                    int n = Convert.ToInt32(id) - 1;
                    renames[n].Date = date;
                }
            }

            listboxDates.ItemsSource = renames;
        }

        private void UseDocument()
        {
            //string xml = "";

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");

            //XmlNode node = xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0];
            //dateright.Text = node.Attributes["time"].Value + "\n";

            //foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            //    xml += (xmlNode.Attributes["currency"].Value + ": " + xmlNode.Attributes["rate"].Value) + "\n";

            //textblockRight.Text = xml;

            List<RenameDate> renames = new List<RenameDate>();
            //XmlDocument xmlDoc = new XmlDocument();

            //xmlDoc.Load("RenamerLog.xml");
            foreach (XmlNode nod in xmlDoc.DocumentElement.ChildNodes)
            {
                int id = Convert.ToInt32(nod.Attributes["id"].Value);
                renames.Add(new RenameDate() { ID = id, Date = nod.ChildNodes[0].InnerText });
            }

        }

        private void FillRenameDates()
        {
            List<RenameDate> renameDates = new List<RenameDate>();

            xmlDoc.Load("RenamerLog.xml");
            foreach (XmlNode nod in xmlDoc.DocumentElement.ChildNodes)
            {
                int id = Convert.ToInt32(nod.Attributes["id"].Value);
                renameDates.Add(new RenameDate() { ID = id, Date = nod.ChildNodes[0].InnerText });
            }

            listboxDates.ItemsSource = renameDates;
        }

        private void FillRenameTitles(int id)
        {
            List<RenameTitle> renamesTiles = new List<RenameTitle>();
            XmlNode rename = null;

            foreach (XmlNode nod in xmlDoc.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["id"].Value == id.ToString())
                {
                    rename = nod;
                    break;
                }
            }

            XmlNode titles = GetNode(rename, "Titles");   // rename.ChildNodes[1];
            foreach (XmlNode nod in titles)
            {
                int _id = Convert.ToInt32(nod.Attributes["id"].Value);
                string _title = nod.ChildNodes[0].InnerText;
                renamesTiles.Add(new RenameTitle() { ID = _id, Title = _title });
            }

            RenameTitles = renamesTiles;
            listboxTitles.ItemsSource = renamesTiles;
        }

        private void FillRenameFiles(int id)
        {
            List<RenameFile> renameFiles = new List<RenameFile>();
            XmlNode rename = null;

            foreach (XmlNode nod in xmlDoc.DocumentElement.ChildNodes)
            {
                if (nod.Attributes["id"].Value == id.ToString())
                {
                    rename = nod;
                    break;
                }
            }

            string fid = "";
            XmlNode files = GetNode(rename, "Files");
            foreach (XmlNode nod in files)
            {
                if ((nod.NodeType == XmlNodeType.Element) && (nod.Name == "File"))
                {
                    if (!String.IsNullOrEmpty(nod.Attributes["id"].Value))
                    {
                        fid = nod.Attributes["id"].Value;
                    }
                }
                int _id = Convert.ToInt32(fid);
                string _name = nod.ChildNodes[0].InnerText;
                renameFiles.Add(new RenameFile() { ID = _id, Name = _name });
            }

            RenamFiles = renameFiles;
            listboxFiles.ItemsSource = renameFiles;
        }

        private XmlNode GetNode(XmlNode start, string nodeName)
        {
            XmlNode xnode = null;
            foreach (XmlNode nod in start.ChildNodes)
            {
                if (nod.Name == nodeName)
                {
                    xnode = nod;
                    break;
                }
            }
            return xnode;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
