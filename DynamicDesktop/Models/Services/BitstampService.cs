using DynamicDesktop.Models.Views.Bitstamp;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DynamicDesktop
{
    public sealed class BitstampService
    {
        /// <summary>
        /// Get the rate of a specificed symbol from Bitstamp.
        /// </summary>
        /// <param name="symbol">Symbol should be 6 characters i.e. two currencies, e.g. xlmgbp</param>
        /// <returns>rate</returns>
        public async Task<decimal?> GetRateAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentNullException(nameof(symbol));

            string response;

            using (var wc = new WebClient())
                response = await wc.DownloadStringTaskAsync($"https://www.bitstamp.net/api/v2/ticker/{symbol}");

            return JsonConvert.DeserializeObject<BitstampRate>(response)?.High;
        }
    }
}
