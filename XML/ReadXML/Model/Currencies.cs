using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml;

namespace ReadXML.Model
{
    public class Currencies : ObservableCollection<Currency>
    {
        private static Currencies _currencies = new Currencies();
        private Currencies() { }       // singleton classe wird nur einmal instanziiert
        public DateTime Date { get; private set; }

        public static Currencies Load()
        {
            _currencies.Clear();
            string address = $"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";

            _currencies.Add(new Currency("EUR", 1.0m));
            using (var reader = new XmlTextReader(address))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("Cube"))
                    {
                        string date = reader.GetAttribute("time");
                        if (date != null)
                        {
                            _currencies.Date = DateTime.Parse(date);
                        }
                        else if (reader.GetAttribute("currency") != null)
                        {
                            string currencyCode = reader.GetAttribute("currency");
                            string currencyRate = reader.GetAttribute("rate");
                            var rate = decimal.Parse(currencyRate, CultureInfo.InvariantCulture);
                            _currencies.Add(new Currency(currencyCode, rate));
                        }
                    }
                }
            }

            #region Alternativ mit XmlDocument:
            //var doc = new XmlDocument();
            //doc.Load(address);

            //XmlNode timeNode = doc.SelectSingleNode("//@time");
            //if (timeNode.Value != null)
            //{
            //    _currencies.Date = DateTime.Parse(timeNode.Value);
            //}
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            //nsmgr.AddNamespace("ecb", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref");
            //XmlNodeList currencyNodes = doc.DocumentElement.SelectNodes("//ecb:Cube[@currency]", nsmgr);
            //foreach (XmlNode node in currencyNodes)
            //{
            //    string currencyCode = node.Attributes["currency"].Value;
            //    string rateString = node.Attributes["rate"].Value;
            //    var rate = decimal.Parse(rateString, CultureInfo.InvariantCulture);

            //    var currency = new Currency(currencyCode, rate);
            //    _currencies.Add(currency);
            //}
            #endregion

            return _currencies;
        }
    }
}
