using OrderManager.Interface;
using OrderManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManager.Oms
{
    public class BBBOms : Ioms
    {
        private IFileReader _fileReader = null;
        public BBBOms()
        {
            _fileReader = new FileReader();
        }

        public async Task ExportOms(IEnumerable<Transaction> transactions)
        {
            var results = from t in transactions
                               where t.Oms.Trim().ToUpper() == "BBB"
                               select new { t.Securities.Cusip, t.Portfolio.PortfolioCode, t.Nominal, t.TransactionType };

            await _fileReader.Write(@"\files\results.bbb", results);
        }
    }
}
