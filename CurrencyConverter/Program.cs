using System;
using System.Configuration;
using System.Windows.Forms;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromCurrency = "USD";
            Console.WriteLine("**********{0} CurrencyConverter**********", fromCurrency);
            Console.WriteLine();

            string[] availableCurrency = CurrencyConverter.GetCurrencyTags();

            Console.WriteLine("Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency));
            Console.WriteLine();

            Console.WriteLine("Insert Currency you want to convert TO");
            string toCurrency = Console.ReadLine();

            double exchangeRate = CurrencyConverter.GetBestExchangeRate(fromCurrency.ToUpper(), toCurrency.ToUpper());
            string msg = fromCurrency.ToUpper() + " TO " + toCurrency.ToUpper() + " = " + exchangeRate;

            var printMode = ConfigurationManager.AppSettings["PrintMode"];
            if (printMode == "console")
                Console.WriteLine(msg);
            else
                MessageBox.Show(msg);

            Console.ReadLine();
        }
    }
}
