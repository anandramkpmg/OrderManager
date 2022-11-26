using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Interface
{
    public interface Ioms
    {
        Task ExportOms(IEnumerable<Transaction> transactions);
    }
}
