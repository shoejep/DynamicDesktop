using System;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Interfaces
{
    public interface IProvider
    {
        string Name { get; }
        string Description { get; }

        Task<string> GenerateTextAsync();
        TimeSpan Delay { get; }
    }
}
