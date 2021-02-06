using DynamicDesktop.Models.Providers;
using DynamicDesktop.Models.Services;
using SixLabors.ImageSharp;
using System.Threading.Tasks;

namespace DynamicDesktop
{
    public sealed class Program
    {
        public async static Task Main(string[] args)
        {
            (int width, int height) = Screen.Dimensions();
            var imageService = new ImageService();
            var defaultFont = imageService.GetDefaultFont();
            var provider = new CurrentTimeProvider();

            while (true)
            {
                var text = await provider.GenerateTextAsync();

                using (var img = imageService.GenerateTextImg(width, height, text, defaultFont, Color.Black, Color.White))
                    await Wallpaper.Set(img, Wallpaper.Style.Centered);

                await Task.Delay(provider.Delay);
            }
        }
    }
}
