using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestipsSignalFunctions.Models
{
    public class StockSecurity
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal LastSale { get; set; }
        public string MarketCap { get; set; }               
        public string MarketCapNumericDollars { get; set; }                         
        public string IpoYear { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string SumaryQuoteUrl { get; set; }
        public string Exchange { get; set; }
    }
}
