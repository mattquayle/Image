using System.Reflection;
using System.Net.Mime;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ResizeImageCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var imagePNG = Image.Load("Image.png");
            {
                imagePNG.SaveAsJpeg("image.jpg");
            }
            using var image = Image.Load("image.jpg");
            {
                ImageMetadata metadata = image.Metadata;
                double currentDPI = metadata.HorizontalResolution;
                double resizeRatio = 300 / currentDPI;

			    int targetWidth = (int)Math.Round((image.Width * resizeRatio)); 
			    int targetHeight = (int)Math.Round((image.Height * resizeRatio));
                
			    metadata.HorizontalResolution = 300;
                metadata.VerticalResolution = 300;

                image.Mutate(x => x.Resize(targetWidth, targetHeight));

                image.Save("imageResized.jpg");
            }
        }
    }
}