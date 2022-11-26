using CsvHelper.Configuration.Attributes;

namespace OrderManager.Models
{
    public class Portfolio 
    {
        [Name("PortfolioId")]
        public int PortfolioId { get; set; }
        [Name("PortfolioCode")]
        public string PortfolioCode { get; set; }
    }
}
