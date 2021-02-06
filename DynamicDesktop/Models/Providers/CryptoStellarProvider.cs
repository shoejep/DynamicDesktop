using DynamicDesktop.Models.Views.Interfaces;
using System;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Providers
{
    public class CryptoStellarProvider : IProvider
    {
        public TimeSpan Delay => TimeSpan.FromHours(3);

        public async Task<string> GenerateTextAsync()
        {
            var rate = await new BitstampService().GetRateAsync("xlmgbp");

            if (!rate.HasValue)
                return string.Empty;

            return $"XLM/GBP\n{decimal.Round(rate.Value * 100m, 0)}p";
        }
    }
}
