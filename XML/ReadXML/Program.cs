using ReadXML.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ReadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Currency> currencies = new ObservableCollection<Currency>();
            currencies = Currencies.Load();

            foreach (var c in currencies)
            {
                Debug.Print($"{c.CurrencyCode} rate= {c.Rate}");
            }
        }
    }
}
