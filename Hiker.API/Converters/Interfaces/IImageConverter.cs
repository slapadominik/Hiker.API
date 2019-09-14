using System.Drawing;

namespace Hiker.API.Converters.Interfaces
{
    public interface IImageConverter
    {
        byte[] Convert(Image img);
    }
}