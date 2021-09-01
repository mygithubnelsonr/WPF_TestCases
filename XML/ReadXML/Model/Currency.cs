namespace ReadXML.Model
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public string FlagPath { get; set; }

        public Currency(string currencyCode, decimal rate)
        {
            CurrencyCode = currencyCode;
            Rate = rate;
            FlagPath = $"/Resources/Images/Countries/{currencyCode}.png";
        }
    }
}
