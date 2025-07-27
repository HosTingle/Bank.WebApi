using Banka.Cekirdek.YardımcıHizmetler.Results;
using Banka.Varlıklar.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka.İs.Soyut
{
    public interface ICurrencyExchangeService
    {
        Task<IDataResult<ExchangeRatesResponse>> GetExchangeRatesAsync();
    }
}
