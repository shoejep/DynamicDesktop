using DynamicDesktop.Models.Views.Interfaces;
using System;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Providers
{
    public class CurrentTimeProvider : IProvider
    {
        public TimeSpan Delay => TimeSpan.FromSeconds(1);

        public async Task<string> GenerateTextAsync() => DateTime.Now.ToString();
    }
}
