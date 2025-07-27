using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Varlıklar.DTOs
{
    public class ExchangeRatesResponse
    {
        public string BaseCurrency { get; set; } = "TRY"; // Sabit TRY bazlı olacak
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; } = new Dictionary<string, decimal>();
    }

}
