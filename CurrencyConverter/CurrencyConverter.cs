using CurrencyConverter.CurrencyProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter
{
    class CurrencyConverter
    {
        public static string[] GetCurrencyTags()
        {
            //TODO: update list
            return new string[] {"eur", "usd", "jpy", "bgn", "czk", "dkk", "gbp", "huf", "ltl", "lvl"
            , "pln", "ron", "sek", "chf", "nok", "hrk", "rub", "try", "aud", "brl", "cad", "cny", "hkd", "idr", "ils"
            , "inr", "krw", "mxn", "myr", "nzd", "php", "sgd", "zar"};
        }

        public static double GetBestExchangeRate(string from, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                return 0;

            List<double> exchangeRates = new List<double>
                {
                    OpenExchangeRates.GetExchangeRate(from, to),
                    CurrencyLayer.GetExchangeRate(from, to)
                };

            return exchangeRates.Min();

        }
    }
}
