using Banka.Cekirdek.YardımcıHizmetler.Results;
using Banka.İs.Soyut;
using Banka.Varlıklar.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Banka.İs.Somut
{


    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private readonly HttpClient _httpClient;

        public CurrencyExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IDataResult<ExchangeRatesResponse>> GetExchangeRatesAsync()
        {
            try
            {
                // Burada base=TRY, sadece TRY karşılığı isteniyor
                string url = "https://api.exchangerate.host/latest?base=TRY";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return new ErrorDataResult<ExchangeRatesResponse>($"HTTP error: {response.StatusCode}");

                var json = await response.Content.ReadAsStringAsync();

                var doc = JsonDocument.Parse(json);

                var root = doc.RootElement;

                var date = root.GetProperty("date").GetDateTime();
                var ratesElement = root.GetProperty("rates");

                var rates = new Dictionary<string, decimal>();

                foreach (var property in ratesElement.EnumerateObject())
                {
                    rates[property.Name] = property.Value.GetDecimal();
                }

                var result = new ExchangeRatesResponse
                {
                    BaseCurrency = "TRY",
                    Date = date,
                    Rates = rates
                };

                return new SuccessDataResult<ExchangeRatesResponse>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ExchangeRatesResponse>($"Exception: {ex.Message}");
            }
        }
    }

}
