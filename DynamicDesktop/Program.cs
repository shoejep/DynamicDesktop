using DynamicDesktop.Models.Enums;
using DynamicDesktop.Models.Interfaces;
using DynamicDesktop.Models.Providers;
using DynamicDesktop.Models.Services;
using SixLabors.ImageSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDesktop
{
    public sealed class Program
    {
        public async static Task Main(string[] args)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("******** Dynamic Desktop ********");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("Providers");
            Console.WriteLine("=========");

            var provider = SelectProvider();

            if (provider == null)
            {
                Console.WriteLine("Could not find the provider you selected");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("You have selected: ");
            Console.WriteLine();
            Console.WriteLine(provider.Name);
            Console.WriteLine(provider.Description);
            Console.WriteLine();

            (int width, int height) = Screen.Dimensions();
            var imageService = new ImageService();
            var defaultFont = imageService.GetDefaultFont();

            while (true)
            {
                var text = await provider.GenerateTextAsync();

                using (var img = imageService.GenerateTextImg(width, height, text, defaultFont, Color.Black, Color.White))
                    await Wallpaper.Set(img, Wallpaper.Style.Centered);

                await Task.Delay(provider.Delay);
            }
        }

        private static IProvider SelectProvider()
        {
            var providerTypes = Enum.GetValues(typeof(ProviderType)).Cast<ProviderType>();

            foreach (var providerType in providerTypes)
            {
                var provider = GetProviderByType(providerType);
                Console.WriteLine($"{(int)providerType}) {provider.Name}");
            }

            Console.Write($"{Environment.NewLine}Select a provider: ");

            var providerSelection = Console.ReadLine();

            if (Enum.TryParse(providerSelection, out ProviderType providerTypeSelected))
                return GetProviderByType(providerTypeSelected);

            return null;
        }

        private static IProvider GetProviderByType(ProviderType type)
        {
            switch (type)
            {
                default:
                    return null;
                case ProviderType.CurrentTime:
                    return new CurrentTimeProvider();
                case ProviderType.DirectoryWatcher:
                    return new DirectoryWatcherProvider();
                case ProviderType.MessyDesktop:
                    return new MessyDesktopProvider();
                case ProviderType.CryptoStellar:
                    return new CryptoStellarProvider();
            }
        }
    }
}
