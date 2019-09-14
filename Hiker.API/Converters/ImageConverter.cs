using System.Drawing;
using System.IO;
using Hiker.API.Converters.Interfaces;

namespace Hiker.API.Converters
{
    public class ImageConverter : IImageConverter
    {
        public byte[] Convert(Image img)
        {
            using (var memoryStream = new MemoryStream())
            {
                img.Save(memoryStream, img.RawFormat);
                return memoryStream.ToArray();
            }
        }
    }
}