using Newtonsoft.Json;
using System;
using System.Net;

namespace CurrencyConverter
{
    public class Utils
    {
        public static T GetJsonObjectFromUrl<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception ex) { Console.WriteLine(ex); }

                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
