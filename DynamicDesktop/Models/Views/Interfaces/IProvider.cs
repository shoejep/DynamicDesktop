using System;
using System.Threading.Tasks;

namespace DynamicDesktop.Models.Views.Interfaces
{
    public interface IProvider
    {
        Task<string> GenerateTextAsync();
        TimeSpan Delay { get; }
    }
}
