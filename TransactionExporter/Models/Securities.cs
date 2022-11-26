using CsvHelper.Configuration.Attributes;

namespace TransactionExporter.Models
{
    public class Securities
    {
        [Name("SecurityId")]
        public int SecurityId { get; set; }
        [Name("ISIN")]
        public string Isin { get; set; }
        [Name("Ticker")]
        public string Ticker { get; set; }
        [Name("CUSIP")]
        public string Cusip { get; set; }
    }
}
