using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Models
{
    public static class Mapper
    {
        // TODO : Would like to auto map like we do in auto mapper to follow seperation of concern, need to figure out how to do in CSV helper
        public static IEnumerable<Transaction> Map(IEnumerable<Transaction> transactions, IEnumerable<Securities> securities, IEnumerable<Portfolio> portfolios)
        {
            foreach (var tran in transactions)
            {
                tran.Securities = securities.FirstOrDefault(x => x.SecurityId == tran.SecurityId);
                tran.Portfolio = portfolios.FirstOrDefault(x => x.PortfolioId == tran.PortfolioId);
            }
            return transactions;
        }
    }
}
