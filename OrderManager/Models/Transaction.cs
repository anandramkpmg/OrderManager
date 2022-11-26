using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TransactionExporter.Models
{
    public class Transaction
    {
        [Name("SecurityId")]
        public int SecurityId { get; set; }
        [Name("PortfolioId")]
        public int PortfolioId { get; set; }
        [Name("Nominal")]
        public decimal Nominal { get; set; }
        [Name("OMS")]
        [MaxLength(3)]
        public string Oms { get; set; }
        [Name("TransactionType")]
        public string TransactionType { get; set; }
        [Ignore]
        public Portfolio Portfolio { get; set; }
        [Ignore]
        public Securities Securities { get; set; }
    }
}
