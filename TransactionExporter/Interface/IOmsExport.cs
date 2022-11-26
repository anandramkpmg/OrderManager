using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionExporter.Models;

namespace TransactionExporter.Interface
{
    public interface Ioms
    {
        Task ExportOms(IEnumerable<Transaction> transactions);
    }
}
