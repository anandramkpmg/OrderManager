using CsvHelper.Configuration.Attributes;
using OrderManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Models
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
