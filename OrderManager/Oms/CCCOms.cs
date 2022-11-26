using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionExporter.Interface;
using TransactionExporter.Models;

namespace OrderManager.Oms
{
    public class CCCOms : Ioms
    {
        private IFileReader _fileReader = null;
        public CCCOms()
        {
            _fileReader = new FileReader();
        }
        
        public async Task ExportOms(IEnumerable<Transaction> transactions)
        {
            var filteredData = from t in transactions
                               where t.Oms.Trim().ToUpper() == "CCC"
                               select new { t.Portfolio.PortfolioCode, t.Securities.Ticker, t.Nominal, t.TransactionType };

            await _fileReader.Write(@"\files\results.ccc", filteredData);
        }
    }
}
