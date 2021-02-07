using DynamicDesktop.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Providers
{
    public class CurrentTimeProvider : IProvider
    {
        public TimeSpan Delay => TimeSpan.FromSeconds(1);

        public string Name => "Current Time";

        public string Description => "Display the current time";

        public async Task<string> GenerateTextAsync() => DateTime.Now.ToString();
    }
}
