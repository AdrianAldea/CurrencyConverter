using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.CurrencyProviders
{
    public class OpenExchangeRates
    {
        static string apiUrl = "https://openexchangerates.org/api/latest.json?app_id=1de86dfd996b4c9da20c0b3fa6eefaa4&base=";

        public static double GetExchangeRate(string from, string to)
        {
            OpenExchangeRatesModel model = Utils.GetJsonObjectFromUrl<OpenExchangeRatesModel>(apiUrl + from);
            model.Rates.TryGetValue(to, out double exchangeRate);

            return exchangeRate;
        }

        private class OpenExchangeRatesModel
        {
            [JsonProperty("disclaimer")]
            public string Disclaimer { get; set; }

            [JsonProperty("license")]
            public Uri License { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("base")]
            public string Base { get; set; }

            [JsonProperty("rates")]
            public Dictionary<string, double> Rates { get; set; }
        }
    }
}
