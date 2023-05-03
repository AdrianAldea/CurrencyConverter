using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.CurrencyProviders
{
    public class CurrencyLayer
    {
        static string apiUrl = "http://www.apilayer.net/api/live?access_key=6653c3ea32932753a5c4a956ddc7de27";

        public static double GetExchangeRate(string from, string to)
        {
            OpenExchangeRatesModel model = Utils.GetJsonObjectFromUrl<OpenExchangeRatesModel>(apiUrl);
            model.Quotes.TryGetValue(from + to, out double exchangeRate);

            return exchangeRate;
        }

        private class OpenExchangeRatesModel
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("terms")]
            public Uri Terms { get; set; }

            [JsonProperty("privacy")]
            public Uri Privacy { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("quotes")]
            public Dictionary<string, double> Quotes { get; set; }
        }
    }
}
