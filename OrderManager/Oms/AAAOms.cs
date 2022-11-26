using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionExporter.Interface;
using TransactionExporter.Models;

namespace OrderManager.Oms
{
    public class AAAOms : Ioms
    {
        private IFileReader _fileReader = null;
        public AAAOms()
        {
            _fileReader = new FileReader();
        }

        public async Task ExportOms(IEnumerable<Transaction> transactions)
        {
            var filteredData = from t in transactions
                               where t.Oms.Trim().ToUpper() == "AAA"
                               select new { t.Securities.Isin, t.Portfolio.PortfolioCode, t.Nominal, t.TransactionType };

            await _fileReader.Write(@"\files\results.aaa", filteredData);
        }
    }
}
