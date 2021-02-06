using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DynamicDesktop.Models.Services
{
    public sealed class ImageService
    {
        public Image<Rgba32> GenerateTextImg(int width, int height, string text, Font font, Color background, Color foreground)
        {
            var img = new Image<Rgba32>(width, height, background);

            img.Mutate(x => x.DrawText(new TextGraphicsOptions
            {
                TextOptions = new TextOptions
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }, text, font, foreground, new PointF(width / 2f, height / 2f)));

            return img;
        }

        public Font GetDefaultFont() => new Font(SystemFonts.Find("Arial"), 128f, FontStyle.Bold);
    }
}
