using CsvHelper.Configuration.Attributes;

namespace TransactionExporter.Tests
{
    public class Transaction
    {
        [Name("PortfolioCode")]
        public string PortfolioCode { get; set; }
        [Name("Nominal")]
        public decimal Nominal { get; set; }
        [Name("TransactionType")]
        public string TransactionType { get; set; }
    }

    public class TransactionA : Transaction
    {
        [Name("Isin")]
        public string Isin { get; set; }
    }

    public class TransactionB : Transaction
    {
        [Name("Cusip")]
        public string Cusip { get; set; }
    }

    public class TransactionC : Transaction
    {
        [Name("Ticker")]
        public string Ticker { get; set; }
    }
}
